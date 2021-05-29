using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Core.Intefaceses.Utilities.Security;
using Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security
{
    public class TokenHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public TokenHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        public Token CreateToken(User user, IEnumerable<Core.Models.Claim> claims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateSecurityToken(_tokenOptions, user, signingCredentials, claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new Token
            {
                AccessToken = token,
                Expiration = _accessTokenExpiration,
                RefreshToken = CreateRefreshToken()
            };

        }

        public JwtSecurityToken CreateSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, IEnumerable<Core.Models.Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, claims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private List<System.Security.Claims.Claim> SetClaims(User user, IEnumerable<Core.Models.Claim> claims)
        {
            var securityClaims = new List<System.Security.Claims.Claim>()
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.Id.ToString()),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.Email),
                new System.Security.Claims.Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}")
            };
            foreach (var claim in claims)
            {
                securityClaims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, claim.Name));
            }
            return securityClaims;
        }

        private string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}

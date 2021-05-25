using Core.AutoMapper.DTOs;
using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using Core.Intefaceses.Utilities.Security;
using Core.Models;
using Core.Utilities.Results;
using Core.Utilities.Security;
using System.Collections.Generic;
using System.Linq;

namespace Service.Services
{
    public class UserService : Service<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository, IUserRepository userRepository, ITokenHelper tokenHelper) : base(unitOfWork, repository)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }
        public Response<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userRepository.GetClaims(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return Response<AccessToken>.Success(accessToken, 200);
        }

        public Response<IEnumerable<Claim>> GetClaims(int userId)
        {
            var result = _userRepository.GetClaims(userId);
            return Response<IEnumerable<Claim>>.Success(result, 200);
        }

        public Response<User> Login(UserDto userDto)
        {
            var userToCheck = _userRepository.Where(x => x.Email == userDto.Email).FirstOrDefault();
            if (userToCheck == null)
            {
                return Response<User>.Fail("the user does not exist", 401);
            }

            if (!HashHelper.VerifyPasswordHash(userDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return Response<User>.Fail("invalid password", 401);
            }

            return Response<User>.Success(userToCheck, 200);
        }

        public Response<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userRepository.AddAsync(user);
            _unitOfWork.CommitAsync();
            return Response<User>.Success(user, 200);
        }
    }
}

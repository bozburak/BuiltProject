using Core.AutoMapper.DTOs;
using Core.Intefaces.Repositories;
using Core.Intefaces.Services;
using Core.Intefaces.UnitOfWorks;
using Core.Intefaces.Utilities.Security;
using Core.Models;
using Core.Utilities.Results;
using Core.Utilities.Security;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public Response<Token> CreateAccessToken(User user)
        {
            var claims = _userRepository.GetClaims(user.Id);
            var token = _tokenHelper.CreateToken(user, claims);
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(10);
            _userRepository.Update(user);
            _unitOfWork.CommitAsync();
            return Response<Token>.Success(token, 200);
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
            _userRepository.Add(user);
            _unitOfWork.Commit();
            return Response<User>.Success(user, 200);
        }
    }
}

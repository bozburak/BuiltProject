using Core.AutoMapper.DTOs;
using Core.Models;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Intefaces.Services
{
    public interface IUserService : IService<User, UserDto>
    {
        Response<IEnumerable<Claim>> GetClaims(int userId);
        Response<User> Register(UserForRegisterDto userForRegisterDto, string password);
        Response<User> Login(UserDto userDto);
        Response<Token> CreateAccessToken(User user);
    }
}

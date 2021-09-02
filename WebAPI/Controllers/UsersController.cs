using Microsoft.AspNetCore.Mvc;
using Core.AutoMapper.DTOs;
using Core.Intefaces.Services;
using System.Linq;
using Core.Utilities.Results;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserDto userDto)
        {
            var userToLogin = _userService.Login(userDto);
            if (userToLogin.Errors != null)
            {
                return BadRequest(userToLogin);
            }

            var result = _userService.CreateAccessToken(userToLogin.Data);
            return Ok(result);
        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            if (_userService.Where(x => x.Email == userForRegisterDto.Email).Data.Count() > 0)
            {
                return BadRequest(Response<string>.Fail("exist user", 400));
            }

            var registerResult = _userService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _userService.CreateAccessToken(registerResult.Data);
            return Ok(result);
        }
    }
}

using Application.Services.UserService;
using Core.DTOs.IdentityDTOS;
using Microsoft.AspNetCore.Mvc;
using Simple_Banking_System.HandleResponses;

namespace Simple_Banking_System.Controllers
{
    public class AuthenController : BaseController
    {
        private readonly IUserService userService;

        public AuthenController(IUserService _userService)
        {
            userService = _userService;

        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {


            var user = await userService.Login(loginDto);
            if (user == null)
            {
                return Unauthorized(new ApiException(401, false, "You are not authorized"));
            }
            return Ok(user);

        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {


            var user = await userService.Register(registerDto);
            if (user == null)
            {
                return BadRequest(new ApiException(400, false, "Email already Exist"));
            }
            return Ok(user);

        }

    }
}

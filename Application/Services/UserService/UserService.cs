using Application.Services.TokenService;
using Core.DTOs.IdentityDTOS;
using Core.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ITokenService tokenService;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public UserService(ITokenService _tokenService,
            SignInManager<AppUser> _signInManager,
            UserManager<AppUser> _userManager)
        {
            tokenService = _tokenService;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return null;

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return null;

            return new UserDto
            {
                Displayname = user.DisplayName,
                Email = user.Email,
                Token = await tokenService.CreateTokenAsync(user)
            };

        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var user = await userManager.FindByEmailAsync(registerDto.Email);

            if (user != null)
                return null;

            var appuser = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email.Split('@')[0],

            };

            var result = await userManager.CreateAsync(appuser, registerDto.Password);

            if (!result.Succeeded)
                return null;

            return new UserDto
            {
                Displayname = appuser.DisplayName,
                Email = appuser.Email,
                Token = await tokenService.CreateTokenAsync(appuser)

            };
        }
    }
}

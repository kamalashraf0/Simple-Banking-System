using Core.DTOs.IdentityDTOS;

namespace Application.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> Login(LoginDto loginDto);

        Task<UserDto> Register(RegisterDto registerDto);
    }
}

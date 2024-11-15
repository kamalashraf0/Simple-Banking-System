using Core.IdentityModels;

namespace Application.Services.TokenService
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser appUser);
    }
}

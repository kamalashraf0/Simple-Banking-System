using Microsoft.AspNetCore.Identity;

namespace Core.IdentityModels
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}

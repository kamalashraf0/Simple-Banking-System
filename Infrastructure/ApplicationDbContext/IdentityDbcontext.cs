using Core.IdentityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ApplicationDbContext
{
    public class IdentityDbcontext : IdentityDbContext<AppUser>
    {
        public IdentityDbcontext(DbContextOptions<IdentityDbcontext> options) : base(options)
        {

        }
    }
}

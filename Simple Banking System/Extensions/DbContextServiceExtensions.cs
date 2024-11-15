using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Simple_Banking_System.Extensions
{
    public static class DbContextServiceExtensions
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BankDbCotext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<IdentityDbcontext>
                (options => options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

            return services;
        }


    }
}

using Application.Handlers;
using Application.Mapping;
using Application.Services.AccountService;
using Application.Services.CustomerService;
using Application.Services.TokenService;
using Application.Services.TransactionService;
using Application.Services.UserService;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace Simple_Banking_System.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(MapperProfile));
            //services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateAccountHandler).Assembly));
            //services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetAccountByIdHandler).Assembly));
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(AssemblyCQRS).Assembly));
            return services;
        }
    }
}

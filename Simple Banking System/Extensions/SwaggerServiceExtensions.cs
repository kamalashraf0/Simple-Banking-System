using Microsoft.OpenApi.Models;

namespace Simple_Banking_System.Extensions
{
    public static class SwaggerServiceExtensions
    {
        private const string Bearer = "Bearer";
        private const string Authorization = "Authorization";
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {


                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ApiDemo",
                    Version = "v1",
                    Description = "API documentation for the Banking System."
                });



                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Description = $"JWT Authorization header using the {Bearer} scheme. Example: \"{Authorization}: {Bearer} {{token}}\"",
                    Name = Authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = Bearer,
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = Bearer
                    }
                };

                c.AddSecurityDefinition(Bearer, jwtSecurityScheme);


                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, new List<string>() }

                });
            });

            return services;


        }
    }
}

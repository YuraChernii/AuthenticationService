using Core.Repositories;
using Domain.Services;
using Infrastructure.Models.Configurations;
using Infrastructure.Persistence.AuthDatabase;
using Infrastructure.Persistence.AuthDatabase.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.TokenServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AuthContext>(options =>
                options.UseSqlServer(config.GetConnectionString("AuthDatabase")));
            services.AddConfigurations(config);
            services.AddRepositories();
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IPasswordHashingService, PasswordHashingService>();

            return services;
        }

        private static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<JwtTokenConfigs>(config.GetSection("JwtTokenConfigs"));

            return services;
        }
    }
}
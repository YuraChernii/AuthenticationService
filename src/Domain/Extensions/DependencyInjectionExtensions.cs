using Core.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserDomainService, UserDomainService>();

            return services;
        }
    }
}
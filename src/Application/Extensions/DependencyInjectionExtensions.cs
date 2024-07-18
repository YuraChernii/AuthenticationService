using Application.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly));
            services.AddAutoMapper(typeof(DependencyInjectionExtensions));
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserApplicationService, UserApplicationService>();

            return services;
        }
    }
}
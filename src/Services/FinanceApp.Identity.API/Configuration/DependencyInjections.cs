using FinanceApp.Core.Commands;
using FinanceApp.Identity.API.Application.Commands;

namespace FinanceApp.Identity.API.Configuration
{
    public static class DependencyInjections
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserCommandHandler, UserCommandHandler>();
            services.AddScoped<IUserCommand, UserCommand>();

            return services;
        }
    }
}

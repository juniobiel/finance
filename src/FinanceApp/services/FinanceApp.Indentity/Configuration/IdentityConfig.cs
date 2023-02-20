using FinanceApp.Indentity.API.Data;
using FinanceApp.Indentity.API.Extensions;
using FinanceApp.Services.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace FinanceApp.Indentity.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityApplicationDbContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<IdentityApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddJwtConfiguration(configuration);

            return services;
        }
    }
}

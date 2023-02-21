using FinanceApp.Identity.API.Data;
using FinanceApp.Identity.API.Extensions;
using FinanceApp.Services.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Identity.API.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfig( this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<IdentityContext>(options => options.
                UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddSignInManager<SignInManager<IdentityUser>>()
                .AddUserManager<UserManager<IdentityUser>>()
                .AddDefaultTokenProviders();

            services.AddJwtConfiguration(configuration);

            return services;
        }
    }
}

using FinanceApp.Budget.API.Data;
using FinanceApp.Services.Core.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Budget.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration( this IServiceCollection services, IConfiguration configuration )
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddDbContext<BudgetContext>(options => options
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration( this IApplicationBuilder app, IWebHostEnvironment env )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}

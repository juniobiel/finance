using FinanceApp.Services.Core.Identity;

namespace FinanceApp.Indentity.API.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration( this IServiceCollection services )
        {
            services.AddControllers();

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

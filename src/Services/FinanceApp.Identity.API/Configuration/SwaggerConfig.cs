using Microsoft.OpenApi.Models;

namespace FinanceApp.Identity.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration( this IServiceCollection services )
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Finance App Identity API",
                    Description = "Api do identity para finance app",
                    Contact = new OpenApiContact() { Name = "Gabriel Junio", Email = "gabrieljunio.fp@gmail.com"},
                    License = new OpenApiLicense() { Name = "GNU", Url = new Uri("https://www.gnu.org/licenses/lgpl-3.0.html") }
                });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration( this IApplicationBuilder app )
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            return app;
        }
    }
}

﻿using FinanceApp.Services.Core.Identity;

namespace FinanceApp.Identity.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration( this IServiceCollection services )
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

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
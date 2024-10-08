using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Amplifund.Assignment.Logger;
using Amplifund.Assignment.Data;
using Serilog;

namespace Amplifund.Assignment.API.Core
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureAPIService(this WebApplicationBuilder webApplicationBuilder)
        {
            var services = webApplicationBuilder.Services;
            var config = webApplicationBuilder.Configuration;
            var logger = services.CreateLogger(config);

            webApplicationBuilder.Host.UseSerilog(logger);

            logger.Information("Start configuring API services.");

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.UseCamelCasing(true);
                });

            services.AddSwaggerGen((options) =>
            {
                options.EnableAnnotations();
            });

            // I am going to just hard-code the connection string :P
            ConfigureDataBase(services, $"Data Source=app_database.db;");

            logger.Information("Completed configuring API services.");

            return services;
        }

        public static void RunApp(this WebApplicationBuilder webApplicationBuilder)
        {
            var app = webApplicationBuilder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }

        private static void ConfigureDataBase(IServiceCollection services, string connectionString)
        {
            services.ConfigureDataBase(connectionString);
        }
    }
}

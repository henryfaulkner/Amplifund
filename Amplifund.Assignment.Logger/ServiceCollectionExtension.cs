using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Amplifund.Assignment.Logger
{
    public static class ServiceCollectionExtension
    {
        public static ILogger CreateLogger(this IServiceCollection services, IConfiguration configuration)
        {
            var serilogLogger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("Logs/log-.txt", 
                rollingInterval: RollingInterval.Day, 
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

            Log.Logger = serilogLogger;

            return serilogLogger;
        }
    }
}

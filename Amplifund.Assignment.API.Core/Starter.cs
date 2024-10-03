namespace Amplifund.Assignment.API.Core
{
    public class Starter
    {
        public static void Main(string[] args)
        {

        }
        public static WebApplicationBuilder CreateAPIBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = builder.Environment.EnvironmentName;
            });

            return builder;
        }
    }
}

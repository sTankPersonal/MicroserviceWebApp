using BuildingBlocks.CrossCutting.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace RecipeMicroservice.Infrastructure.Logging
{
    public static class LoggingServiceRegistration
    {
        public static IServiceCollection AddLoggingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DefaultLoggingService>();
            services.Configure<LoggingOptions>(configuration.GetSection("LoggingOptions"));
            services.AddScoped<ILoggingService, LoggingService>();
            return services;
        }
    }
}

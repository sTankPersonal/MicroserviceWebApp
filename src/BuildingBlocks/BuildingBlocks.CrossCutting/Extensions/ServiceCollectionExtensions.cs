using BuildingBlocks.CrossCutting.Correlation;
using BuildingBlocks.CrossCutting.Logging;
using BuildingBlocks.CrossCutting.Exceptions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BuildingBlocks.CrossCutting.Validation;

namespace BuildingBlocks.CrossCutting.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCrossCutting(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure Correlation Middleware
            services.Configure<CorrelationOptions>(options => { configuration.GetSection("CorrelationOptions").Bind(options); });
            services.AddScoped<ICorrelationIdAccessor, CorrelationIdAccessor>();
            services.AddSingleton<ICorrelationService, DefaultCorrelationService>();

            // Configure Logging Middleware
            services.AddSingleton<ILoggingService, DefaultLoggingService>();
            services.Configure<LoggingOptions>(options => { configuration.GetSection("LoggingOptions").Bind(options); });

            // Configure Exception Middleware
            services.AddSingleton<IExceptionService, DefaultExceptionService>();
            services.Configure<ExceptionOptions>(options => { configuration.GetSection("ExceptionOptions").Bind(options); });

            // DTO Validation Filter
            services.AddScoped<IValidationFilter, DefaultValidationFilter>();

            return services;
        }
    }
}

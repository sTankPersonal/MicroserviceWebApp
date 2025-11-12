using BuildingBlocks.CrossCutting.Correlation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Infrastructure.Correlation
{
    public static class CorrelationServiceRegistration
    {
        public static IServiceCollection AddCorrelationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CorrelationOptions>(configuration.GetSection("CorrelationOptions"));
            services.AddScoped<DefaultCorrelationService<CorrelationOptions>>();
            services.AddScoped<DefaultCorrelationIdAccessor>();
            services.AddScoped<ICorrelationIdAccessor, CorrelationIdAccessor>();
            services.AddScoped<ICorrelationService, CorrelationService>();
            return services;
        }
    }
}

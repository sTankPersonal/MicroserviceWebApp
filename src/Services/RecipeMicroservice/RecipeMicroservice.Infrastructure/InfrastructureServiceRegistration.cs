using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeMicroservice.Infrastructure.Cloud;
using RecipeMicroservice.Infrastructure.Correlation;
using RecipeMicroservice.Infrastructure.Exception;
using RecipeMicroservice.Infrastructure.Logging;
using RecipeMicroservice.Infrastructure.Persistence;

namespace RecipeMicroservice.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCloudServices(configuration);
            services.AddCorrelationServices(configuration);
            services.AddExceptionServices(configuration);
            services.AddLoggingServices(configuration);
            services.AddPersistenceServices(configuration);
            return services;
        }
    }
}

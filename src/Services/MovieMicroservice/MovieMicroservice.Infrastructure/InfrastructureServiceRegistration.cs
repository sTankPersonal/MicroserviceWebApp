using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieMicroservice.Infrastructure.Cloud;
using MovieMicroservice.Infrastructure.Correlation;
using MovieMicroservice.Infrastructure.Exception;
using MovieMicroservice.Infrastructure.Logging;
using MovieMicroservice.Infrastructure.Persistence;

namespace MovieMicroservice.Infrastructure
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

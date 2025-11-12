using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeMicroservice.Infrastructure.Exception;
using RecipeMicroservice.Infrastructure.Logging;
using RecipeMicroservice.Infrastructure.Persistence;
using Template.Infrastructure.BackgroundTasks;
using Template.Infrastructure.Cloud;
using Template.Infrastructure.Configuration;
using Template.Infrastructure.Correlation;
using Template.Infrastructure.Email;
using Template.Infrastructure.Identity;

namespace Template.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBackgroundTasksServices(configuration);
            services.AddCloudServices(configuration);
            services.AddConfigurationServices(configuration);
            services.AddCorrelationServices(configuration);
            services.AddEmailServices(configuration);
            services.AddExceptionServices(configuration);
            services.AddIdentityServices(configuration);
            services.AddLoggingServices(configuration);
            services.AddPersistenceServices(configuration);
            return services;
        }
    }
}

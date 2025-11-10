using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeMicroservice.Infrastructure.Cloud.FileStorage;

namespace RecipeMicroservice.Infrastructure.Cloud
{
    public static class CloudServiceRegistration
    {
        public static IServiceCollection AddCloudServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Cloud File Storage services
            services.AddCloudFileStorageServices(configuration);
            return services;
        }
    }
}

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

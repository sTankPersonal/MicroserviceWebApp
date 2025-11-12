using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Infrastructure.Cloud
{
    public static class CloudServiceRegistration
    {
        public static IServiceCollection AddCloudServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register Cloud services
            return services;
        }
    }
}

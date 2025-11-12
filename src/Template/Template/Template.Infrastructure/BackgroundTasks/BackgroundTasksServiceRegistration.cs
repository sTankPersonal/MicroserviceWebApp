using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Template.Infrastructure.BackgroundTasks
{
    public static class BackgroundTasksServiceRegistration
    {
        public static IServiceCollection AddBackgroundTasksServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHostedService<SampleBackgroundTask>();
            return services;
        }
    }
}

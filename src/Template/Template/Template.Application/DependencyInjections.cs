using Microsoft.Extensions.DependencyInjection;

namespace Template.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register all application services here
            // Example:
            // services.AddTransient<IExampleService, ExampleService>();
            return services;
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using RecipeService.Application.Interfaces.Services;
using RecipeService.Application.Services;

namespace RecipeService.Application.Dependencies
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            return services;
        }
    }
}

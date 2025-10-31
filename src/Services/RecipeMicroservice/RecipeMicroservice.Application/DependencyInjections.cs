using Microsoft.Extensions.DependencyInjection;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Services;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Infrastructure.Persistence.Repositories;

namespace RecipeMicroservice.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUnitService, UnitService>();

            

            return services;
        }
    }
}

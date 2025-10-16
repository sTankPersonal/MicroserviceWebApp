using Microsoft.Extensions.DependencyInjection;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Services;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Infrastructure.Repositories;

namespace RecipeMicroservice.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IInstructionService, InstructionService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUnitService, UnitService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IInstructionRepository, InstructionRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();

            return services;
        }
    }
}

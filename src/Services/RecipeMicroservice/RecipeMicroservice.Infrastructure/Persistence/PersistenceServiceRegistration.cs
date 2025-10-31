using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Infrastructure.Persistence.Repositories;

namespace RecipeMicroservice.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RecipeMicroserviceDbContext>(options =>
                options.UseNpgsql(Environment.GetEnvironmentVariable("NEON_CONNECTION")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();

            return services;
        }
    }
}

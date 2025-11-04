using BuildingBlocks.CrossCutting.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieMicroservice.Infrastructure.Persistence.Repositories;
using MovieMicroservice.Domain.Interfaces;

namespace MovieMicroservice.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DatabaseOptions from configuration
            services.Configure<DatabaseOptions>(configuration.GetSection("DatabaseOptions"));

            // Register RecipeMicroserviceDbContext with PostgreSQL provider
            services.AddDbContext<MovieMicroserviceDbContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value.ConnectionString);
            });

            // Register repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}

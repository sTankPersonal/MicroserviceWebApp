using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieMicroservice.Application.Interfaces.Services;
using MovieMicroservice.Application.Services;

namespace MovieMicroservice.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMovieService, MovieService>();
            
            return services;
        }
    }
}

using BuildingBlocks.CrossCutting.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MovieMicroservice.Infrastructure.Exception
{
    public static class ExceptionServiceRegistration
    {
        public static IServiceCollection AddExceptionServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ExceptionOptions>(configuration.GetSection("ExceptionOptions"));
            services.AddScoped<IExceptionService, ExceptionService>();
            services.AddScoped<DefaultExceptionService>();
            return services;
        }
    }
}

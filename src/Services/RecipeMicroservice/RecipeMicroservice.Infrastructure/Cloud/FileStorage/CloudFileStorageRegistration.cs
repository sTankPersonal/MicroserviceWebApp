using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RecipeMicroservice.Domain.Interfaces;

namespace RecipeMicroservice.Infrastructure.Cloud.FileStorage
{
    public static class CloudFileStorageRegistration
    {
        public static IServiceCollection AddCloudFileStorageServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure GoogleOptions from configuration
            services.Configure<GoogleOptions>(configuration.GetSection("GoogleOptions"));

            // Register DriveService as a singleton
            services.AddSingleton(serviceProvider =>
            {
                IOptions<GoogleOptions> googleOptions = serviceProvider.GetRequiredService<IOptions<GoogleOptions>>();

                BaseClientService.Initializer initializer = new()
                {
                    HttpClientInitializer = CredentialFactory
                        .FromJson<ServiceAccountCredential>(googleOptions.Value.ServiceAccountJson)
                        .ToGoogleCredential()
                        .CreateScoped(DriveService.Scope.DriveFile),
                    ApplicationName = googleOptions.Value.ApplicationName,
                };

                return new DriveService(initializer);
            });

            services.AddScoped<IPhotoFileStorage, GoogleDriveCloudFileStorage>();
            return services;
        }
    }
}

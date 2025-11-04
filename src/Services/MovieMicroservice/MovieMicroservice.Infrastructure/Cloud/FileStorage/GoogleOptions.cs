using BuildingBlocks.CrossCutting.Utils;

namespace MovieMicroservice.Infrastructure.Cloud.FileStorage
{
    public class GoogleOptions
    {
        private string _serviceAccountJson = string.Empty;
        public string ServiceAccountJson
        {
            get => _serviceAccountJson.ThrowIfNullOrEmpty($"{nameof(GoogleOptions)}.{nameof(ServiceAccountJson)}");
            set => _serviceAccountJson = value;
        }

        private string _applicationName = string.Empty;
        public string ApplicationName
        {
            get => _applicationName.ThrowIfNullOrEmpty($"{nameof(GoogleOptions)}.{nameof(ApplicationName)}");
            set => _applicationName = value;
        }
    }
}

using BuildingBlocks.CrossCutting.Logging;
using Microsoft.AspNetCore.Http;

namespace MovieMicroservice.Infrastructure.Logging
{
    public class LoggingService(DefaultLoggingService defaultLoggingService) : ILoggingService
    {
        private readonly DefaultLoggingService _defaultLoggingService = defaultLoggingService;
        public Task LogRequestAsync(HttpContext context)
        {
            return _defaultLoggingService.LogRequestAsync(context);
        }

        public Task LogResponseAsync(HttpContext context)
        {
            return _defaultLoggingService.LogResponseAsync(context);
        }
    }
}

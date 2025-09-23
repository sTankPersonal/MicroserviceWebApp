
using BuildingBlocks.CrossCutting.Logging;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public class LoggingMiddleware(RequestDelegate next, ILoggingService loggingService) : BaseMiddleware(next)
    {
        protected readonly ILoggingService _loggingService = loggingService;

        protected override async Task PreProcessAsync(HttpContext context)
        {
            await _loggingService.LogRequestAsync(context);
        }

        protected override async Task PostProcessAsync(HttpContext context)
        {
            await _loggingService.LogResponseAsync(context);
        }
    }
}

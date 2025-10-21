using BuildingBlocks.CrossCutting.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public class LoggingMiddleware(RequestDelegate next) : BaseMiddleware(next)
    {
        public override async Task PreProcessAsync(HttpContext context)
        {
            ILoggingService loggingService = context.RequestServices.GetRequiredService<ILoggingService>();
            await loggingService.LogRequestAsync(context);
        }

        public override async Task PostProcessAsync(HttpContext context)
        {
            ILoggingService loggingService = context.RequestServices.GetRequiredService<ILoggingService>();
            await loggingService.LogResponseAsync(context);
        }
    }
}

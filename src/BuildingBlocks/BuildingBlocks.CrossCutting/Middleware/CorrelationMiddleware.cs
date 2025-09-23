using BuildingBlocks.CrossCutting.Correlation;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public class CorrelationMiddleware(RequestDelegate next, ICorrelationService correlationService) : BaseMiddleware(next)
    {
        private readonly ICorrelationService _correlationService = correlationService;

        protected override async Task PreProcessAsync(HttpContext context)
        {
            await _correlationService.GetOrSetCorrelationId(context);
        }

        protected override async Task PostProcessAsync(HttpContext context)
        {
            await _correlationService.SetCorrelationId(context);
        }
    }
}

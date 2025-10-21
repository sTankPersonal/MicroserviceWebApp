using BuildingBlocks.CrossCutting.Correlation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public class CorrelationMiddleware(RequestDelegate next) : BaseMiddleware(next)
    {

        public override async Task PreProcessAsync(HttpContext context)
        {
            ICorrelationService correlationService = context.RequestServices.GetRequiredService<ICorrelationService>();
            await correlationService.GetOrSetCorrelationId(context);

            await correlationService.SetCorrelationId(context);
        }

        public override Task PostProcessAsync(HttpContext context)
        {
            return Task.CompletedTask;
            //ICorrelationService correlationService = context.RequestServices.GetRequiredService<ICorrelationService>();
            //await correlationService.SetCorrelationId(context);
        }
    }
}

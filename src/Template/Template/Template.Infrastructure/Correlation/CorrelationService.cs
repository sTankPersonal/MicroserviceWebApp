using BuildingBlocks.CrossCutting.Correlation;
using Microsoft.AspNetCore.Http;

namespace Template.Infrastructure.Correlation
{
    public class CorrelationService(DefaultCorrelationService<CorrelationOptions> defaultService) : ICorrelationService
    {
        public Task GetOrSetCorrelationId(HttpContext httpContext)
        {
            return defaultService.GetOrSetCorrelationId(httpContext);
        }

        public Task SetCorrelationId(HttpContext httpContext)
        {
            return defaultService.SetCorrelationId(httpContext);
        }
    }

}

using BuildingBlocks.CrossCutting.Correlation;
using Microsoft.AspNetCore.Http;

namespace MovieMicroservice.Infrastructure.Correlation
{
    public class CorrelationService(DefaultCorrelationService defaultService) : ICorrelationService
    {
        private readonly DefaultCorrelationService _defaultService = defaultService;

        public Task GetOrSetCorrelationId(HttpContext httpContext)
        {
            return _defaultService.GetOrSetCorrelationId(httpContext);
        }

        public Task SetCorrelationId(HttpContext httpContext)
        {
            return _defaultService.SetCorrelationId(httpContext);
        }
    }

}

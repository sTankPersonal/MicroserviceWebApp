using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Correlation
{
    public interface ICorrelationService
    {
        Task GetOrSetCorrelationId(HttpContext httpContext);
        Task SetCorrelationId(HttpContext httpContext);
    }
}

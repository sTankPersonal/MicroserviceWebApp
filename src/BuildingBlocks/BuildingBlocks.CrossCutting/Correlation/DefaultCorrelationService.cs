using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Correlation
{
    public class DefaultCorrelationService(ICorrelationIdAccessor correlationIdAccessor, IOptions<CorrelationOptions> correlationOptions) : ICorrelationService
    {
        private readonly ICorrelationIdAccessor _correlationAccessor = correlationIdAccessor;
        private readonly CorrelationOptions _options = correlationOptions.Value;

        public Task GetOrSetCorrelationId(HttpContext httpContext)
        {
            if (httpContext.Request.Headers.TryGetValue(_options.HeaderName, out var correlationId))
            {
                _correlationAccessor.SetCorrelationId(correlationId!);
            }
            else
            {
                string newCorrelationId = Guid.NewGuid().ToString();
                _correlationAccessor.SetCorrelationId(newCorrelationId);
                httpContext.Request.Headers[_options.HeaderName] = newCorrelationId;
            }
            return Task.CompletedTask;
        }

        public Task SetCorrelationId(HttpContext httpContext)
        {
            httpContext.Response.Headers[_options.HeaderName] = _correlationAccessor.GetCorrelationId() ?? string.Empty;
            return Task.CompletedTask;
        }
    }
}

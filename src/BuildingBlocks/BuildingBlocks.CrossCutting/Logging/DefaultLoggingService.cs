using BuildingBlocks.CrossCutting.Correlation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BuildingBlocks.CrossCutting.Logging
{
    public class DefaultLoggingService(ILogger<DefaultLoggingService> logger, CorrelationIdAccessor correlationIdAccessor, IOptions<LoggingOptions> loggingOptions) : ILoggingService
    {
        private readonly LoggingOptions _loggingOptions = loggingOptions.Value;
        private readonly ILogger<DefaultLoggingService> _logger = logger;
        private readonly CorrelationIdAccessor _correlationIdAccessor = correlationIdAccessor;

        public Task LogRequestAsync(HttpContext context)
        {
            _logger.LogInformation(
                "Incoming Request: {Method} {Path}{QueryString} CorrelationId={CorrelationId}",
                context.Request.Method,
                context.Request.Path,
                context.Request.QueryString,
                _correlationIdAccessor.GetCorrelationId()
            );
            return Task.CompletedTask;
        }

        public Task LogResponseAsync(HttpContext context)
        {
            _logger.LogInformation(
                "Outgoing Response: {StatusCode} CorrelationId={CorrelationId}",
                context.Response.StatusCode,
                _correlationIdAccessor.GetCorrelationId()
            );
            return Task.CompletedTask;
        }
    }
}

using BuildingBlocks.CrossCutting.Correlation;
using BuildingBlocks.SharedKernel.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BuildingBlocks.CrossCutting.Exceptions
{
    public class DefaultExceptionService(IOptions<ExceptionOptions> exceptionOptions, ICorrelationIdAccessor correlationIdAccessor) : IExceptionService
    {
        private readonly ExceptionOptions _options = exceptionOptions.Value;
        private readonly ICorrelationIdAccessor _correlationIdAccessor = correlationIdAccessor;
        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            ErrorResponse response = _options.IncludeExceptionDetails
                ? new ErrorResponse(
                    "An unexpected error occurred.",
                    new Dictionary<string, string[]>
                    {
                        { "Exception", new[] { exception.Message } },
                        { "StackTrace", new[] { exception.StackTrace ?? string.Empty } }
                    },
                    _correlationIdAccessor.GetCorrelationId()
                )
                : new ErrorResponse(
                    "An unexpected error occurred.",
                    null,
                    _correlationIdAccessor.GetCorrelationId()
                );

            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }
}

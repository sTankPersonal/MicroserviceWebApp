namespace BuildingBlocks.SharedKernel.Results
{
    public record ErrorResponse
    (
        string Message,
        IDictionary<string, string[]>? Errors = null,
        string? CorrelationId = null
    );
}

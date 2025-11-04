namespace BuildingBlocks.CrossCutting.Correlation
{
    public class DefaultCorrelationIdAccessor : ICorrelationIdAccessor
    {
        private string? _correlationId;
        public string? GetCorrelationId() => _correlationId;
        public void SetCorrelationId(string correlationId) => _correlationId = correlationId;
    }
}

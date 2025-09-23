namespace BuildingBlocks.CrossCutting.Correlation
{
    public interface ICorrelationIdAccessor
    {
        string? GetCorrelationId();
        void SetCorrelationId(string correlationId);
    }
}

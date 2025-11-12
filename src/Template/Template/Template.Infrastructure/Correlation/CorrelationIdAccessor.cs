using BuildingBlocks.CrossCutting.Correlation;

namespace Template.Infrastructure.Correlation
{
    public class CorrelationIdAccessor(DefaultCorrelationIdAccessor defaultCorrelationIdAccessor) : ICorrelationIdAccessor
    {
        private readonly DefaultCorrelationIdAccessor _defaultCorrelationIdAccessor = defaultCorrelationIdAccessor;
        public string? GetCorrelationId()
        {
            return _defaultCorrelationIdAccessor.GetCorrelationId();
        }

        public void SetCorrelationId(string correlationId)
        {
            _defaultCorrelationIdAccessor.SetCorrelationId(correlationId);
        }
    }
}

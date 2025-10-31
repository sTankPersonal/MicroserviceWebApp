using BuildingBlocks.CrossCutting.Correlation;
using Microsoft.Extensions.Options;

namespace RecipeMicroservice.Infrastructure.Correlation
{
    public class CorrelationIdAccessor(ICorrelationIdAccessor correlationIdAccessor, IOptions<CorrelationOptions> correlationOptions) : DefaultCorrelationService(correlationIdAccessor, correlationOptions)
    {

    }
}

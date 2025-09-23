

using BuildingBlocks.SharedKernel.Events;

namespace BuildingBlocks.SharedKernel.Entities
{
    public interface IEventDispatcher
    {
        Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}

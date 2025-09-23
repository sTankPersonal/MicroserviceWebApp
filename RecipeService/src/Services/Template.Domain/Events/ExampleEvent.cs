
using BuildingBlocks.SharedKernel.Events;

namespace Template.Domain.Events
{
    public class ExampleEvent(Guid id) : IDomainEvent
    {
        public Guid EntityId { get; } = id;
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}

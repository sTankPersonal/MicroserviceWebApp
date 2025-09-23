
namespace BuildingBlocks.EventBus.IntegrationEvents
{
    public abstract class IntegrationEvent
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }

        protected IntegrationEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}

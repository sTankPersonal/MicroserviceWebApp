
using BuildingBlocks.EventBus.IntegrationEvents;

namespace BuildingBlocks.EventBus.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken = default);
        void Subscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>;
        void SubscribeDynamic<TEventHandler>()
            where TEventHandler : IDynamicIntegrationEventHandler;
        void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : IntegrationEvent
            where TEventHandler : IIntegrationEventHandler<TEvent>;
        void UnsubscribeDynamic<TEventHandler>()
            where TEventHandler : IDynamicIntegrationEventHandler;
    }
}

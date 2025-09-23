
namespace BuildingBlocks.EventBus.EventBus
{
    public interface IDynamicIntegrationEventHandler
    {
        Task HandleAsync(string eventName, string message, CancellationToken cancellationToken = default);
    }
}

namespace RecipeMicroservice.Presentation.Interfaces.Models
{
    public interface IHasAggregate<TSelf, TAggregateId> where TSelf : IHasAggregate<TSelf, TAggregateId>
    {
        TAggregateId AggregateId { get; set; }
        TSelf WithAggregateId(TAggregateId aggregateId);
    }
}

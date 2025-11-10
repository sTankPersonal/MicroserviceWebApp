namespace RecipeMicroservice.Presentation.Interfaces.Models
{
    public interface IHasRecipeAggregate<TSelf> : IHasAggregate<TSelf, Guid> where TSelf : IHasAggregate<TSelf, Guid>
    {
        string RecipeName { get; set; }
    }
}

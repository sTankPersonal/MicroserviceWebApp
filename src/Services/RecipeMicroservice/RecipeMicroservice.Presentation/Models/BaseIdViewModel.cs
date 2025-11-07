namespace RecipeMicroservice.Presentation.Models
{
    public abstract class BaseIdViewModel<Tid>
    {
        public required Tid Id { get; init; }
    }
}

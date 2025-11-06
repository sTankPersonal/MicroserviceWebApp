namespace RecipeMicroservice.Presentation.Models
{
    public class RecipeAggregateViewModels
    {
        public required Guid RecipeId {get; init; }
        // For display purposes
        public string RecipeName { get; init; } = string.Empty;
    }
}

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class RecipeCategoryViewModel : RecipeAggregateViewModels
    {
        public Guid Id { get; init; }
        public Guid CategoryId { get; init; }
        public string CategoryName { get; set; } = string.Empty;
    }
}

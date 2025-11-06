namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class ListRecipeIngredientViewModel : BaseListViewModel<RecipeIngredientViewModel>
    {
        public string? SearchName { get; set; } = string.Empty;
    }
}

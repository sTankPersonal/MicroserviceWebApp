namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class ListIngredientViewModel : BaseListViewModel<IngredientViewModel>
    {
        public string? SearchName { get; set; } = null;
    }
}

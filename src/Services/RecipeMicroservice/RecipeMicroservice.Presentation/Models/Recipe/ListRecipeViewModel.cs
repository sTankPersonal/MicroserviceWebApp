namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class ListRecipeViewModel : BaseListViewModel<RecipeViewModel>
    {
        public FilterViewModel Filter { get; init; } = new FilterViewModel();
    }
}

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class ListRecipeCategoryViewModel : BaseListViewModel<RecipeCategoryViewModel>
    {
        public string ? SearchName { get; set; } = null;
    }
}

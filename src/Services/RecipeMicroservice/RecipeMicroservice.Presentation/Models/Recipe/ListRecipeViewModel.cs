using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class ListRecipeViewModel : BaseListViewModel<RecipeViewModel>, IHasFilter<ListRecipeViewModel, FilterRecipeViewModel>
    {
        public FilterRecipeViewModel Filter { get; set; } = new FilterRecipeViewModel();

        public ListRecipeViewModel WithFilter(FilterRecipeViewModel filter)
        {
            Filter = filter;
            return this;
        }
    }
}

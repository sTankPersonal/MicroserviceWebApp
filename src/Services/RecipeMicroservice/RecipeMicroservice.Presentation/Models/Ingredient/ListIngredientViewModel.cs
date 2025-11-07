using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class ListIngredientViewModel : BaseListViewModel<IngredientViewModel>, IHasFilter<ListIngredientViewModel, FilterIngredientViewModel>
    {
        public FilterIngredientViewModel Filter { get; set; } = new();
        public ListIngredientViewModel WithFilter(FilterIngredientViewModel filter)
        {
            Filter = filter;
            return this;
        }
    }
}

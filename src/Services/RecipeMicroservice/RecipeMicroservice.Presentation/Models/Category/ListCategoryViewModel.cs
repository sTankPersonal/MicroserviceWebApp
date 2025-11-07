using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class ListCategoryViewModel : BaseListViewModel<CategoryViewModel>, IHasFilter<ListCategoryViewModel, FilterCategoryViewModel>
    {
        public FilterCategoryViewModel Filter { get; set; } = new();

        public ListCategoryViewModel WithFilter(FilterCategoryViewModel filter)
        {
            Filter = filter;
            return this;
        }
    }
}

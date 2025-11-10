using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class ListUnitViewModel : BaseListViewModel<UnitViewModel>, IHasFilter<ListUnitViewModel, FilterUnitViewModel>
    {
        public FilterUnitViewModel Filter { get; set; } = new();

        public ListUnitViewModel WithFilter(FilterUnitViewModel filter)
        {
            Filter = filter;
            return this;
        }
    }
}

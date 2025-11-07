using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Application.Interfaces.ViewModels;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class ListUnitViewModel : BaseListViewModel<UnitViewModel>, IViewModelToDto<ListUnitViewModel, PagedResult<UnitDto>>, IViewModelFromDto<ListUnitViewModel, PagedResult<UnitDto>>, IListViewModelWithFilter<ListUnitViewModel, FilterUnitViewModel>
    {
        public FilterUnitViewModel Filter { get; set; } = new();
        public static ListUnitViewModel FromDto(PagedResult<UnitDto> result) => new()
        {
            Items = [.. result.Items.Select(UnitViewModel.FromDto)],
            TotalItems = result.TotalItems,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize
        };

        public static PagedResult<UnitDto> ToDto(ListUnitViewModel viewModel) => new()
        {
            Items = [.. viewModel.Items.Select(UnitViewModel.ToDto)],
            TotalItems = viewModel.TotalItems,
            PageNumber = viewModel.PageNumber,
            PageSize = viewModel.PageSize
        };
        public ListUnitViewModel WithFilter(FilterUnitViewModel filter)
        {
            Filter = filter;
            return this;
        }
    }
}

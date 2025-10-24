using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Unit;

namespace RecipeMicroservice.Presentation.Models.Unit
{
    public class ListUnitViewModel : BaseListViewModel<UnitViewModel>
    {
        public string? SearchName { get; set; }

        public static ListUnitViewModel FromPagedResult(PagedResult<UnitDto> pagedResult)
        {
            return new ListUnitViewModel
            {
                Items = [.. pagedResult.Items.Select(UnitViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems
            };
        }
    }
}

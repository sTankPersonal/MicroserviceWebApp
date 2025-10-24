using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Category;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class ListCategoryViewModel : BaseListViewModel<CategoryViewModel>
    {
        public string? SearchName { get; set; }

        public static ListCategoryViewModel FromPagedResult(PagedResult<CategoryDto> pagedResult)
        {
            return new ListCategoryViewModel
            {
                Items = [..pagedResult.Items.Select(CategoryViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems,
            };
        }
    }
}

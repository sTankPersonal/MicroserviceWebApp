using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeCategory;

namespace RecipeMicroservice.Presentation.Models.RecipeCategory
{
    public class ListRecipeCategoryViewModel : BaseListViewModel<RecipeCategoryViewModel>
    {
        public string ? SearchName { get; set; } = null;
        public static ListRecipeCategoryViewModel FromPagedResult(PagedResult<RecipeCategoryDto> pagedResult)
        {
            return new ListRecipeCategoryViewModel
            {
                Items = [.. pagedResult.Items.Select(RecipeCategoryViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems
            };
        }
    }
}

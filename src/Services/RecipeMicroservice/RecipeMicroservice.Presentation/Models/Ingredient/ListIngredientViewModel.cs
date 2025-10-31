using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Ingredient;

namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class ListIngredientViewModel : BaseListViewModel<IngredientViewModel>
    {
        public string? SearchName { get; set; } = null;
        public static ListIngredientViewModel FromPagedResult(PagedResult<IngredientDto> pagedResult)
        {
            return new ListIngredientViewModel
            {
                Items = [.. pagedResult.Items.Select(IngredientViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems
            };
        }

    }
}

using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class ListRecipeIngredientViewModel : BaseListViewModel<RecipeIngredientViewModel>
    {
        public string? SearchName { get; set; } = null;

        public static ListRecipeIngredientViewModel FromPagedResult(PagedResult<RecipeIngredientDto> pagedResult)
        {
            return new ListRecipeIngredientViewModel
            {
                Items = [.. pagedResult.Items.Select(RecipeIngredientViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems
            };
        }
    }
}

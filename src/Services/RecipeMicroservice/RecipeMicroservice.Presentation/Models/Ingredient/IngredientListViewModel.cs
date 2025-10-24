using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Ingredient;

namespace RecipeMicroservice.Presentation.Models.Ingredient
{
    public class IngredientListViewModel : BaseListViewModel<IngredientViewModel>
    {
        public string SearchName { get; set; } = string.Empty;

        public static IngredientListViewModel FromPagedResult(PagedResult<IngredientDto> pagedResult)
        {
            IngredientListViewModel viewModel = new()
            {
                Items = [.. pagedResult.Items.Select(IngredientViewModel.FromDto)],
                TotalItems = pagedResult.TotalItems,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
            return viewModel;
        }
    }
}

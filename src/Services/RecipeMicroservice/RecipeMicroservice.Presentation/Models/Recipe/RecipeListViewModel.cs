using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Recipe;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class RecipeListViewModel : BaseListViewModel<RecipeViewModel>
    {
        public string SearchName { get; set; } = string.Empty;
        public string SearchCategory { get; set; } = string.Empty;
        public string SearchIngredient { get; set; } = string.Empty;

        public static RecipeListViewModel FromPagedResult(PagedResult<RecipeDto> pagedResult)
        {
            RecipeListViewModel viewModel = new()
            {
                Items = [.. pagedResult.Items.Select(RecipeViewModel.FromDto)],
                TotalItems = pagedResult.TotalItems,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
            return viewModel;
        }

    }
}

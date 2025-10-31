using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Recipe;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class ListRecipeViewModel : BaseListViewModel<RecipeViewModel>
    {
        [Display(Name = "Search Recipe Name")]
        public string? SearchName { get; set; } = null;
        [Display(Name = "Search Categories")]
        public Guid? SearchCategoryId { get; set; } = null;
        [Display(Name = "Search Ingredients")]
        public Guid? SearchIngredientId { get; set; } = null;

        public static ListRecipeViewModel FromPagedResult(PagedResult<RecipeDto> pagedResult)
        {
            return new ListRecipeViewModel
            {
                Items = [.. pagedResult.Items.Select(RecipeViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems
            };
        }
    }
}

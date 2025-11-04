using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class ListRecipeInstructionViewModel : BaseListViewModel<RecipeInstructionViewModel>
    {
        public string? SearchDescription { get; set; } = null;

        public static ListRecipeInstructionViewModel FromPagedResult(PagedResult<RecipeInstructionDto> pagedResult)
        {
            return new ListRecipeInstructionViewModel
            {
                Items = [.. pagedResult.Items.Select(RecipeInstructionViewModel.FromDto)],
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalItems = pagedResult.TotalItems
            };
        }
    }
}

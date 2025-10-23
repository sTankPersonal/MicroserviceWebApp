using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.RecipeInstruction
{
    public class RecipeInstructionListViewModel : BaseListViewModel<RecipeInstructionViewModel>
    {
        public string SearchDescription { get; set; } = string.Empty;
        public static RecipeInstructionListViewModel FromPagedResult(PagedResult<RecipeInstructionDto> pagedResult)
        {
            RecipeInstructionListViewModel viewModel = new()
            {
                Items = [.. pagedResult.Items.Select(RecipeInstructionViewModel.FromDto)],
                TotalItems = pagedResult.TotalItems,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
            return viewModel;
        }
    }
}

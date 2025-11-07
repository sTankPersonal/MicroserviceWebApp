using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeInstructionViewModelMapper
    {
        // Map from Dto to ViewModel
        public static RecipeInstructionViewModel ToViewModel(this RecipeInstructionDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            StepNumber = dto.StepNumber,
            Description = dto.Description,
            RecipeName = dto.RecipeName
        };
        public static ListRecipeInstructionViewModel ToListViewModel(this PagedResult<RecipeInstructionDto> pagedDtos, Guid recipeId) => new()
        {
            Items = pagedDtos.Items.Select(i => i.ToViewModel(recipeId)),
            PageNumber = pagedDtos.PageNumber,
            PageSize = pagedDtos.PageSize,
            TotalItems = pagedDtos.TotalItems
        };
        public static UpdateRecipeInstructionViewModel ToUpdateViewModel(this RecipeInstructionDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            StepNumber = dto.StepNumber,
            Description = dto.Description
        };

        // Map from ViewModel to Dto
        public static CreateRecipeInstructionDto ToCreateDto(this CreateRecipeInstructionViewModel viewModel) => new()
        {
            StepNumber = viewModel.StepNumber,
            Description = viewModel.Description
        };
        public static UpdateRecipeInstructionDto ToUpdateDto(this UpdateRecipeInstructionViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            StepNumber = viewModel.StepNumber,
            Description = viewModel.Description
        };
    }
}

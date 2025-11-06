using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Mappers
{
    /* CreateRecipeInstructionViewModel <-> CreateRecipeInstructionDto
     * ListRecipeInstructionViewModel <-> PagedResult<RecipeInstructionDto>
     * RecipeInstructionViewModel <-> RecipeInstructionDto
     * UpdateRecipeInstructionViewModel <-> UpdateRecipeInstructionDto
     */
    public static class RecipeInstructionViewModelMapper
    {
        public static CreateRecipeInstructionViewModel ToViewModel(this CreateRecipeInstructionDto dto, Guid recipeId) => new()
        {
            RecipeId = recipeId,
            StepNumber = dto.StepNumber,
            Description = dto.Description
        };
        public static CreateRecipeInstructionDto ToDto(this CreateRecipeInstructionViewModel viewModel) => new()
        {
            StepNumber = viewModel.StepNumber,
            Description = viewModel.Description
        };
        public static ListRecipeInstructionViewModel ToViewModel(this PagedResult<RecipeInstructionDto> pagedResult, Guid recipeId) => new()
        {
            Items = [.. pagedResult.Items.Select(item => item.ToViewModel(recipeId))],
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalItems = pagedResult.TotalItems
        };
        public static PagedResult<RecipeInstructionDto> ToDto(this ListRecipeInstructionViewModel viewModel) => new()
        {
            Items = [.. viewModel.Items.Select(ToDto)],
            TotalItems = viewModel.TotalItems,
            PageNumber = viewModel.PageNumber,
            PageSize = viewModel.PageSize
        };
        public static RecipeInstructionViewModel ToViewModel(this RecipeInstructionDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            StepNumber = dto.StepNumber,
            Description = dto.Description
        };
        public static RecipeInstructionDto ToDto(this RecipeInstructionViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            StepNumber = viewModel.StepNumber,
            Description = viewModel.Description
        };
        public static UpdateRecipeInstructionViewModel ToViewModel(this UpdateRecipeInstructionDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            StepNumber = dto.StepNumber,
            Description = dto.Description
        };
        public static UpdateRecipeInstructionDto ToDto(this UpdateRecipeInstructionViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            StepNumber = viewModel.StepNumber,
            Description = viewModel.Description
        };
    }
}

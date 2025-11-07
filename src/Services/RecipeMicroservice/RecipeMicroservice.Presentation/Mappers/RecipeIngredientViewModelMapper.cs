using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeIngredientViewModelMapper
    {
        // Map from Dto to ViewModel
        public static RecipeIngredientViewModel ToViewModel(this RecipeIngredientDto dto, Guid recipeId) => new()
        { 
            Id = dto.Id,
            RecipeId = recipeId,
            IngredientId = dto.IngredientId,
            UnitId = dto.UnitId,
            Quantity = dto.Quantity,
            IngredientName = dto.IngredientName,
            UnitName = dto.UnitName
        };
        public static ListRecipeIngredientViewModel ToListViewModel(this PagedResult<RecipeIngredientDto> pagedDtos, Guid recipeId) => new()
        {
            Items = pagedDtos.Items.Select(i => i.ToViewModel(recipeId)),
            PageNumber = pagedDtos.PageNumber,
            PageSize = pagedDtos.PageSize,
            TotalItems = pagedDtos.TotalItems
        };
        public static UpdateRecipeIngredientViewModel ToUpdateViewModel(this RecipeIngredientDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            UnitId = dto.UnitId,
            IngredientId = dto.IngredientId,
            Quantity = dto.Quantity
        };

        // Map from ViewModel to Dto
        public static CreateRecipeIngredientDto ToCreateDto(this CreateRecipeIngredientViewModel viewModel, Guid recipeId) => new()
        {
            IngredientId = viewModel.IngredientId,
            UnitId = viewModel.UnitId,
            Quantity = viewModel.Quantity
        };

        public static UpdateRecipeIngredientDto ToUpdateDto(this UpdateRecipeIngredientViewModel viewModel, Guid recipeId) => new()
        {
            Id = viewModel.Id,
            IngredientId = viewModel.IngredientId,
            UnitId = viewModel.UnitId,
            Quantity = viewModel.Quantity
        };
    }
}

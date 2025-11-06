using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeIngredientViewModelMapper
    {
        //Create
        public static CreateRecipeIngredientViewModel ToViewModel(this CreateRecipeIngredientDto dto, Guid recipeId) => new()
        {
            RecipeId = recipeId,
            IngredientId = dto.IngredientId,
            UnitId = dto.UnitId,
            Quantity = dto.Quantity
        };
        public static CreateRecipeIngredientDto ToDto(this CreateRecipeIngredientViewModel viewModel) => new()
        {
            IngredientId = viewModel.IngredientId,
            UnitId = viewModel.UnitId,
            Quantity = viewModel.Quantity
        };

        //Update
        public static UpdateRecipeIngredientViewModel ToViewModel(this UpdateRecipeIngredientDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            IngredientId = dto.IngredientId,
            UnitId = dto.UnitId,
            Quantity = dto.Quantity,
            IngredientName = dto.IngredientName,
            UnitName = dto.UnitName
        };
        public static UpdateRecipeIngredientDto ToDto(this UpdateRecipeIngredientViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            IngredientId = viewModel.IngredientId,
            UnitId = viewModel.UnitId,
            Quantity = viewModel.Quantity
        };

        //General
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
        public static RecipeIngredientDto ToDto(this RecipeIngredientViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            RecipeId = viewModel.RecipeId,
            IngredientId = viewModel.IngredientId,
            UnitId = viewModel.UnitId,
            Quantity = viewModel.Quantity,
            IngredientName = viewModel.IngredientName,
            UnitName = viewModel.UnitName
        };

        //List
        public static ListRecipeIngredientViewModel ToViewModel(this PagedResult<RecipeIngredientDto> pagedResult, Guid recipeId) => new()
        {
            Items = [.. pagedResult.Items.Select(item => item.ToViewModel(recipeId))],
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalItems = pagedResult.TotalItems
        };
        public static PagedResult<RecipeIngredientDto> ToDto(this ListRecipeIngredientViewModel viewModel) => new()
        {
            Items = [.. viewModel.Items.Select(item => item.ToDto())],
            PageNumber = viewModel.PageNumber,
            PageSize = viewModel.PageSize,
            TotalItems = viewModel.TotalItems
        };
    }
}

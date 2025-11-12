using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeIngredientViewModelMapper
    {
        // Map from Dto to ViewModel
        public static RecipeIngredientViewModel ToViewModel(this RecipeIngredientDto dto) => new()
        { 
            Id = dto.Id,
            AggregateId = dto.RecipeId,
            IngredientId = dto.IngredientId,
            UnitId = dto.UnitId,
            Quantity = dto.Quantity,
            IngredientName = dto.IngredientName,
            UnitName = dto.UnitName
        };
        public static ListRecipeIngredientViewModel ToListViewModel(this PagedResult<RecipeIngredientDto> pagedDtos) => new()
        {
            Items = pagedDtos.Items.Select(ToViewModel),
            PageNumber = pagedDtos.PageNumber,
            PageSize = pagedDtos.PageSize,
            TotalItems = pagedDtos.TotalItems
        };
        public static ListUpdateRecipeIngredientViewModel ToListUpdateViewModel(this PagedResult<RecipeIngredientDto> pagedDtos) => new()
        {
            Items = pagedDtos.Items.Select(ToUpdateViewModel),
            PageNumber = pagedDtos.PageNumber,
            PageSize = pagedDtos.PageSize,
            TotalItems = pagedDtos.TotalItems
        };
        public static UpdateRecipeIngredientViewModel ToUpdateViewModel(this RecipeIngredientDto dto) => new()
        {
            Id = dto.Id,
            AggregateId = dto.RecipeId,
            IngredientId = dto.IngredientId,
            UnitId = dto.UnitId,
            Quantity = dto.Quantity,
            IngredientName = dto.IngredientName,
            UnitName = dto.UnitName
        };

        // Map from ViewModel to Dto
        public static CreateRecipeIngredientDto ToCreateDto(this CreateRecipeIngredientViewModel viewModel) => new()
        {
            RecipeId = viewModel.AggregateId,
            IngredientId = viewModel.IngredientId,
            UnitId = viewModel.UnitId,
            Quantity = viewModel.Quantity
        };

        public static UpdateRecipeIngredientDto ToUpdateDto(this UpdateRecipeIngredientViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            RecipeId = viewModel.AggregateId, 
            IngredientId = viewModel.IngredientId,
            UnitId = viewModel.UnitId,
            Quantity = viewModel.Quantity
        };
    }
}

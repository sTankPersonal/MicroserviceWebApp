using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeCategory;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeCategoryViewModelMapper
    {
        public static CreateRecipeCategoryViewModel ToViewModel(this CreateRecipeCategoryDto dto) => new()
        {
            CategoryId = dto.CategoryId
        };
        public static CreateRecipeCategoryDto ToDto(this CreateRecipeCategoryViewModel viewModel) => new()
        {
            CategoryId = viewModel.CategoryId
        };
        public static RecipeCategoryViewModel ToViewModel(this RecipeCategoryDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            CategoryId = dto.CategoryId,
            CategoryName = dto.CategoryName
        };
        public static RecipeCategoryDto ToDto(this RecipeCategoryViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            CategoryId = viewModel.CategoryId,
            CategoryName = viewModel.CategoryName
        };
        public static ListRecipeCategoryViewModel ToViewModel(this PagedResult<RecipeCategoryDto> pagedResult, Guid recipeId) => new()
        {
            Items = pagedResult.Items.Select(dto => dto.ToViewModel(recipeId)),
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalItems = pagedResult.TotalItems
        };
        public static PagedResult<RecipeCategoryDto> ToDto(this ListRecipeCategoryViewModel viewModel) => new()
        {
            Items = viewModel.Items.Select(ToDto),
            TotalItems = viewModel.TotalItems,
            PageNumber = viewModel.PageNumber,
            PageSize = viewModel.PageSize
        };
        public static UpdateRecipeCategoryViewModel ToViewModel(this UpdateRecipeCategoryDto dto, Guid recipeId) => new()
        {
            Id = dto.Id,
            RecipeId = recipeId,
            CategoryId = dto.CategoryId,
            CategoryName = dto.CategoryName
        };
        public static UpdateRecipeCategoryDto ToDto(this UpdateRecipeCategoryViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            CategoryId = viewModel.CategoryId,
            CategoryName = viewModel.CategoryName
        };
    }
}

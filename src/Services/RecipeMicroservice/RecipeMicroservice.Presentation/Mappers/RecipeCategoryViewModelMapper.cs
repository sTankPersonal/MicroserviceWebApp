using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeCategory;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeCategoryViewModelMapper
    {
        // Map from Dto to ViewModel
        public static RecipeCategoryViewModel ToViewModel(this RecipeCategoryDto dto) => new()
        {
            Id = dto.Id,
            AggregateId = dto.RecipeId,
            CategoryId = dto.CategoryId,
            CategoryName = dto.CategoryName
        };
        public static ListRecipeCategoryViewModel ToListViewModel(this PagedResult<RecipeCategoryDto> pagedDtos) => new()
        {
            Items = pagedDtos.Items.Select(ToViewModel),
            PageNumber = pagedDtos.PageNumber,
            PageSize = pagedDtos.PageSize,
            TotalItems = pagedDtos.TotalItems
        };
        public static UpdateRecipeCategoryViewModel ToUpdateViewModel(this RecipeCategoryDto dto) => new()
        {
            Id = dto.Id,
            AggregateId = dto.RecipeId,
            CategoryId = dto.CategoryId,
            CategoryName = dto.CategoryName
        };

        // Map from ViewModel to Dto
        public static CreateRecipeCategoryDto ToCreateDto(this CreateRecipeCategoryViewModel viewModel) => new()
        {
            RecipeId = viewModel.AggregateId,
            CategoryId = viewModel.CategoryId
        };
        public static UpdateRecipeCategoryDto ToUpdateDto(this UpdateRecipeCategoryViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            RecipeId = viewModel.AggregateId,
            CategoryId = viewModel.CategoryId
        };
    }
}

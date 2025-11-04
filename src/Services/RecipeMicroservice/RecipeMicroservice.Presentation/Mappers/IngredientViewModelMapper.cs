using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Presentation.Models.Ingredient;

namespace RecipeMicroservice.Presentation.Mappers
{
    /* CreateIngredientViewModelMapper <-> CreateIngredientDto
     * IngredientViewModel <-> IngredientDto
     * ListIngredientViewModel <-> PagedResult<IngredientDto>
     * UpdateIngredientViewModel <-> UpdateIngredientDto
     */
    public static class IngredientViewModelMapper
    {
        public static CreateIngredientViewModel ToViewModel(this CreateIngredientDto dto) => new()
        {
            Name = dto.Name
        };
        public static CreateIngredientDto ToDto(this CreateIngredientViewModel viewModel) => new()
        {
            Name = viewModel.Name
        };

        public static IngredientViewModel ToViewModel(this IngredientDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static IngredientDto ToDto(this IngredientViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            Name = viewModel.Name
        };

        public static ListIngredientViewModel ToViewModel(this PagedResult<IngredientDto> pagedResult) => new()
        {
            Items = [.. pagedResult.Items.Select(item => item.ToViewModel())],
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalItems = pagedResult.TotalItems
        };
        public static PagedResult<IngredientDto> ToDto(this ListIngredientViewModel viewModel) => new(
            [.. viewModel.Items.Select(item => item.ToDto())],
            viewModel.TotalItems,
            viewModel.PageNumber,
            viewModel.PageSize);

        public static UpdateIngredientViewModel ToViewModel(this UpdateIngredientDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static UpdateIngredientDto ToDto(this UpdateIngredientViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            Name = viewModel.Name
        };
    }
}

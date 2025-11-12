using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Ingredient;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class IngredientViewModelMapper
    {
        // Map from DTO to ViewModel
        public static IngredientViewModel ToViewModel(this IngredientDto ingredientDto) => new()
        {
            Id = ingredientDto.Id,
            Name = ingredientDto.Name
        };
        public static ListIngredientViewModel ToListViewModel(this PagedResult<IngredientDto> pagedIngredientDtos) => new()
        {
            Items = pagedIngredientDtos.Items.Select(i => i.ToViewModel()),
            PageNumber = pagedIngredientDtos.PageNumber,
            PageSize = pagedIngredientDtos.PageSize,
            TotalItems = pagedIngredientDtos.TotalItems
        };
        public static UpdateIngredientViewModel ToUpdateViewModel(this IngredientDto ingredientDto) => new()
        {
            Id = ingredientDto.Id,
            Name = ingredientDto.Name
        };

        // Map from ViewModel to DTO
        public static CreateIngredientDto ToCreateDto(this CreateIngredientViewModel createIngredientViewModel) => new()
        {
            Name = createIngredientViewModel.Name
        };
        public static UpdateIngredientDto ToUpdateDto(this UpdateIngredientViewModel updateIngredientViewModel) => new()
        {
            Id = updateIngredientViewModel.Id,
            Name = updateIngredientViewModel.Name
        };

        // Map from FilterViewModel to Filter
        public static FilterIngredient ToFilter(this FilterIngredientViewModel filterViewModel) => new()
        {
            SearchName = filterViewModel.SearchName
        };
        // Map from Filter to FilterViewModel
        public static FilterIngredientViewModel ToFilterViewModel(this FilterIngredient filter) => new()
        {
            SearchName = filter.SearchName ?? string.Empty
        };
    }
}

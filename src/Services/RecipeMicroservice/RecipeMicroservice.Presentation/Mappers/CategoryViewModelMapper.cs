using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Category;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class CategoryViewModelMapper
    {
        // Map from DTO to ViewModel
        public static CategoryViewModel ToViewModel(this CategoryDto categoryDto) => new()
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name
        };
        public static ListCategoryViewModel ToListViewModel(this PagedResult<CategoryDto> pagedCategoryDtos) => new()
        {
            Items = pagedCategoryDtos.Items.Select(c => c.ToViewModel()),
            PageNumber = pagedCategoryDtos.PageNumber,
            PageSize = pagedCategoryDtos.PageSize,
            TotalItems = pagedCategoryDtos.TotalItems
        };
        public static UpdateCategoryViewModel ToUpdateViewModel(this CategoryDto categoryDto) => new()
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name
        };

        // Map from ViewModel to DTO
        public static CreateCategoryDto ToCreateDto(this CreateCategoryViewModel createCategoryViewModel) => new()
        {
            Name = createCategoryViewModel.Name
        };
        public static UpdateCategoryDto ToUpdateDto(this UpdateCategoryViewModel updateCategoryViewModel) => new()
        {
            Id = updateCategoryViewModel.Id,
            Name = updateCategoryViewModel.Name
        };
        // Map from FilterViewModel to Filter
        public static FilterCategory ToFilter(this FilterCategoryViewModel filterViewModel) => new()
        {
            SearchName = filterViewModel.SearchName
        };
        // Map from Filter to FilterViewModel
        public static FilterCategoryViewModel ToFilterViewModel(this FilterCategory filter) => new()
        {
            SearchName = filter.SearchName ?? string.Empty
        };
    }
}

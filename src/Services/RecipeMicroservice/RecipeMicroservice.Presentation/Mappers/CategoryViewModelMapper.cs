using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Presentation.Models.Category;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class CategoryViewModelMapper
    {
        // Category
        public static CategoryViewModel ToViewModel(this CategoryDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name
        };

        public static CategoryDto ToDto(this CategoryViewModel vm) => new()
        {
            Id = vm.Id,
            Name = vm.Name
        };

        // CreateCategory
        public static CreateCategoryViewModel ToViewModel(this CreateCategoryDto dto) => new()
        {
            Name = dto.Name
        };

        public static CreateCategoryDto ToDto(this CreateCategoryViewModel vm) => new()
        {
            Name = vm.Name
        };

        // ListCategory
        public static ListCategoryViewModel ToViewModel(this PagedResult<CategoryDto> paged) => new()
        {
            Items = paged.Items.Select(ToViewModel),
            PageNumber = paged.PageNumber,
            PageSize = paged.PageSize,
            TotalItems = paged.TotalItems
        };

        public static PagedResult<CategoryDto> ToDto(this ListCategoryViewModel vm) => new()
        {
            Items = vm.Items.Select(ToDto),
            TotalItems = vm.TotalItems,
            PageNumber = vm.PageNumber,
            PageSize = vm.PageSize
        };

        // UpdateCategory
        public static UpdateCategoryViewModel ToViewModel(this UpdateCategoryDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static UpdateCategoryDto ToDto(this UpdateCategoryViewModel vm) => new()
        {
            Id = vm.Id,
            Name = vm.Name
        };
    }
}

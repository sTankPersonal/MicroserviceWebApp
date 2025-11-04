using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Presentation.Models.Category;

namespace RecipeMicroservice.Presentation.Mappers
{
    /* CategoryViewModel <-> CategoryDto
     * CreateCategoryViewModel <-> CreateCategoryDto
     * ListCategoryViewModel <-> PagedResult<CategoryDto>
     * UpdateCategoryViewModel <-> UpdateCategoryDto 
     */
    public static class CategoryViewModelMapper
    {
        public static CategoryViewModel ToViewModel(this CategoryDto dto) => new ()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static CategoryDto ToDto(this CategoryViewModel viewModel) => new ()
        {
            Id = viewModel.Id,
            Name = viewModel.Name,
        };
        public static CreateCategoryViewModel ToViewModel(this CreateCategoryDto dto) => new ()
        {
            Name = dto.Name
        };
        public static CreateCategoryDto ToDto(this CreateCategoryViewModel viewModel) => new ()
        {
            Name = viewModel.Name
        };
        public static ListCategoryViewModel ToViewModel(this PagedResult<CategoryDto> pagedResult) => new()
        {
            Items = [.. pagedResult.Items.Select(item => item.ToViewModel())],
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            TotalItems = pagedResult.TotalItems
        };
        public static PagedResult<CategoryDto> ToDto(this ListCategoryViewModel viewModel) => new (
            [.. viewModel.Items.Select(item => item.ToDto())],
            viewModel.TotalItems,
            viewModel.PageNumber,
            viewModel.PageSize);

        public static UpdateCategoryViewModel ToViewModel(this UpdateCategoryDto dto) => new ()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static UpdateCategoryDto ToDto(this UpdateCategoryViewModel viewModel) => new ()
        {
            Id = viewModel.Id,
            Name = viewModel.Name
        };
    }
}

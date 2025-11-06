using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Presentation.Models.Unit;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class UnitViewModelMapper
    {
        public static CreateUnitViewModel ToViewModel(this CreateUnitDto dto) => new()
        {
            Name = dto.Name
        };
        public static CreateUnitDto ToDto(this CreateUnitViewModel viewModel) => new()
        {
            Name = viewModel.Name
        };

        public static ListUnitViewModel ToViewModel(this PagedResult<UnitDto> dtoPagedResult) => new()
        {
            Items = [..dtoPagedResult.Items.Select(ToViewModel)],
            PageNumber = dtoPagedResult.PageNumber,
            PageSize = dtoPagedResult.PageSize,
            TotalItems = dtoPagedResult.TotalItems
        };
        public static PagedResult<UnitDto> ToDto(this ListUnitViewModel viewModel) => new()
        {
            Items = [.. viewModel.Items.Select(ToDto)],
            TotalItems = viewModel.TotalItems,
            PageNumber = viewModel.PageNumber,
            PageSize = viewModel.PageSize
        };

        public static UnitViewModel ToViewModel(this UnitDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static UnitDto ToDto(this UnitViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            Name = viewModel.Name
        };

        public static UpdateUnitViewModel ToViewModel(this UpdateUnitDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        public static UpdateUnitDto ToDto(this UpdateUnitViewModel viewModel) => new()
        {
            Id = viewModel.Id,
            Name = viewModel.Name
        };
    }
}

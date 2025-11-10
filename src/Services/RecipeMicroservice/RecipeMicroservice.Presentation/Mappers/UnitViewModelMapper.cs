using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Unit;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class UnitViewModelMapper
    {
        // Map from DTO to ViewModel
        public static UnitViewModel ToViewModel(this UnitDto unitDto) => new()
        {
            Id = unitDto.Id,
            Name = unitDto.Name
        };

        public static ListUnitViewModel ToListViewModel(this PagedResult<UnitDto> pagedUnitDtos) => new()
        {
            Items = [..pagedUnitDtos.Items.Select(u => u.ToViewModel())],
            PageNumber = pagedUnitDtos.PageNumber,
            PageSize = pagedUnitDtos.PageSize,
            TotalItems = pagedUnitDtos.TotalItems
        };

        public static UpdateUnitViewModel ToUpdateViewModel(this UnitDto unitDto) => new()
        {
            Id = unitDto.Id,
            Name = unitDto.Name
        };

        // Map from ViewModel to DTO
        public static CreateUnitDto ToCreateDto(this CreateUnitViewModel createUnitViewModel) => new()
        {
            Name = createUnitViewModel.Name
        };
        public static UpdateUnitDto ToUpdateDto(this UpdateUnitViewModel updateUnitViewModel) => new()
        {
            Id = updateUnitViewModel.Id,
            Name = updateUnitViewModel.Name
        };

        //Map from FilterViewModel to Filter
        public static FilterUnit ToFilter(this FilterUnitViewModel filterViewModel) => new()
        {
            SearchName = filterViewModel.SearchName
        };
        // Map from Filter to FilterViewModel
        public static FilterUnitViewModel ToFilterViewModel(this FilterUnit filter) => new()
        {
            SearchName = filter.SearchName
        };
    }
}

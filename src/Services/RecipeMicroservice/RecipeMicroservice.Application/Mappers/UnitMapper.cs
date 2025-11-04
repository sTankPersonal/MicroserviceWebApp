using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class UnitMapper
    {
        public static Unit ToEntity(this CreateUnitDto dto) => new()
        {
            Name = dto.Name
        };
        public static Unit ToEntity(this UpdateUnitDto dto, Unit unit)
        {
            unit.Name = dto.Name;
            return unit;
        }
        public static UnitDto ToDto(this Unit unit) => new()
        {
            Id = unit.Id,
            Name = unit.Name
        };
        public static IEnumerable<UnitDto> ToDtos(this IEnumerable<Unit> units) =>
            units.Select(u => u.ToDto());
    }
}

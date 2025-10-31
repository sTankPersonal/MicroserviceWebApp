using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class UnitMapper
    {
        public static Unit ToEntity(this CreateUnitDto dto)
        {
            return new Unit
            {
                Name = dto.Name
            };
        }
        public static UnitDto ToDto(this Unit unit)
        {
            return new UnitDto
            {
                Id = unit.Id,
                Name = unit.Name
            };
        }
        public static IEnumerable<UnitDto> ToDtos(this IEnumerable<Unit> units)
        {
            return units.Select(u => u.ToDto());
        }
    }
}

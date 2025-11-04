using BuildingBlocks.SharedKernel.DomainServices;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Mappers;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
{
    public class UnitService(IUnitRepository unitRepository) : BasicCrudService<Unit, Guid, UnitDto, CreateUnitDto, UpdateUnitDto, FilterUnit>(unitRepository), IUnitService
    {
        protected override Unit ToEntity(CreateUnitDto dto) => dto.ToEntity();
        protected override void ToEntity(UpdateUnitDto dto, Unit entity) => _ = dto.ToEntity(entity);
        protected override UnitDto ToDto(Unit entity) => entity.ToDto();
    }
}

using BuildingBlocks.SharedKernel.DomainServices;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IUnitService : IBasicCrudService<Guid, UnitDto, CreateUnitDto, UpdateUnitDto, FilterUnit>
    {
    }
}

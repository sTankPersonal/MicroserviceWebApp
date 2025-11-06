using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IUnitService : IBasicCrudService<Guid, UnitDto, CreateUnitDto, UpdateUnitDto, FilterUnit>
    {
    }
}

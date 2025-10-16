using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Unit;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IUnitService : IBasicCrudService<Guid, UnitDto, CreateUnitDto, UpdateUnitDto>
    {
        public Task<PagedResult<UnitDto>> GetAllAsync(FilterUnitDto filter);
    }
}

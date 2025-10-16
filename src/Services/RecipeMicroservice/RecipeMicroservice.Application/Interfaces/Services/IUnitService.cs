using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Unit;

namespace RecipeService.Application.Interfaces.Services
{
    public interface IUnitService : IBasicCrudService<Guid, UnitDto, CreateUnitDto, UpdateUnitDto>
    {
        public Task<PagedResult<UnitDto>> GetAllAsync(FilterUnitDto filter);
    }
}

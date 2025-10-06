using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Unit;
using RecipeService.Application.Interfaces.Services;

namespace RecipeService.Application.Services
{
    public class UnitService : IUnitService
    {
        public Task<UnitDto> CreateAsync(CreateUnitDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<UnitDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UnitDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateUnitDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

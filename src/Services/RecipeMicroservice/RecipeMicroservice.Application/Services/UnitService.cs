using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
{
    public class UnitService : IUnitService
    {
        public Task<Guid> CreateAsync(CreateUnitDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<UnitDto>> GetAllAsync(FilterUnit filter)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<UnitDto>> GetAllAsync(PagedQuery query)
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

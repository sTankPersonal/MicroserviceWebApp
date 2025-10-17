using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Infrastructure.Repositories;

namespace RecipeMicroservice.Application.Services
{
    public class UnitService(IUnitRepository unitRepository) : IUnitService
    {
        private readonly IUnitRepository _unitRepository = unitRepository;
        public async Task<Guid> CreateAsync(CreateUnitDto dto)
        {
            Unit unit = new()
            {
                Name = dto.Name
            };
            await _unitRepository.AddAsync(unit);
            return unit.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            Unit? unit = await _unitRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Unit with id {id} not found.");
            await _unitRepository.DeleteAsync(unit);
        }

        public async Task<PagedResult<UnitDto>> GetAllAsync(FilterUnit filter)
        {
            PagedResult<Unit> pagedUnits =  await _unitRepository.GetAllAsync(filter);
            List<UnitDto> unitDtos = [.. pagedUnits.Items
                .Select(u => new UnitDto
                {
                    Id = u.Id,
                    Name = u.Name
                })];
            return new PagedResult<UnitDto>(
                unitDtos,
                pagedUnits.TotalItems,
                pagedUnits.PageNumber,
                pagedUnits.PageSize);
        }

        public async Task<PagedResult<UnitDto>> GetAllAsync(PagedQuery query)
        {
            PagedResult<Unit> pagedUnits =  await _unitRepository.GetAllAsync(query);
            List<UnitDto> unitDtos = [.. pagedUnits.Items
                .Select(u => new UnitDto
                {
                    Id = u.Id,
                    Name = u.Name
                })];
            return new PagedResult<UnitDto>(
                unitDtos,
                pagedUnits.TotalItems,
                pagedUnits.PageNumber,
                pagedUnits.PageSize);
        }

        public async Task<UnitDto?> GetByIdAsync(Guid id)
        {
            Unit? unit = await _unitRepository.GetByIdAsync(id);
            if (unit == null)
            {
                return null;
            }
            return new UnitDto
            {
                Id = unit.Id,
                Name = unit.Name
            };
        }

        public async Task UpdateAsync(Guid id, UpdateUnitDto dto)
        {
            Unit? unit = await _unitRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Unit with id {id} not found.");
            unit.Name = dto.Name;
            await _unitRepository.UpdateAsync(unit);
        }
    }
}

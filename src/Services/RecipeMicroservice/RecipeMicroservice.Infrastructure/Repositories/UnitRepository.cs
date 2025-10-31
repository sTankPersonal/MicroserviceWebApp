using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Infrastructure.Persistence;

namespace RecipeMicroservice.Infrastructure.Repositories
{
    public class UnitRepository(RecipeMicroserviceDbContext dbContext) : IUnitRepository
    {
        private readonly RecipeMicroserviceDbContext _dbContext = dbContext;
        public async Task AddAsync(Unit entity)
        {
            _dbContext.Units.Add(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Unit entity)
        {
            _dbContext.Units.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<PagedResult<Unit>> GetAllAsync(FilterUnit query)
        {
            IQueryable<Unit> units = _dbContext.Units.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                units = units.Where(u => EF.Functions.ILike(u.Name, $"%{query.SearchName}%"));
            }
            int totalItems = await units.CountAsync();
            List<Unit> items = await units.OrderBy(u => u.Name).ThenBy(u => u.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Unit>(items, totalItems, query.PageNumber, query.PageSize);
        }
        public async Task<PagedResult<Unit>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Unit> units = _dbContext.Units.AsQueryable();
            int totalItems = await units.CountAsync();
            List<Unit> items = await units.OrderBy(u => u.Name).ThenBy(u => u.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Unit>(items, totalItems, query.PageNumber, query.PageSize);
        }
        public async Task<Unit?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Units.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task UpdateAsync(Unit entity)
        {
            _dbContext.Units.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

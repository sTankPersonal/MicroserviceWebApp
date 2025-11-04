using Microsoft.EntityFrameworkCore;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Domain.Interfaces;
using MovieMicroservice.Domain.Specifications;
using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Infrastructure.Persistence;

namespace MovieMicroservice.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository(MovieMicroserviceDbContext dbContext) : ICategoryRepository
    {
        private readonly MovieMicroserviceDbContext _dbContext = dbContext;
        public async Task AddAsync(Category entity)
        {
            _dbContext.Categories.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Category entity)
        {
            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<Category>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Category> categories = _dbContext.Categories.AsQueryable();
            int totalItems = await categories.CountAsync();
            List<Category> items = await categories.OrderBy(c => c.Name).ThenBy(c => c.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Category>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<PagedResult<Category>> GetAllAsync(FilterCategory query)
        {
            IQueryable<Category> categories = _dbContext.Categories.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                categories = categories.Where(c => EF.Functions.ILike(c.Name, $"%{query.SearchName}%"));
            }
            int totalItems = await categories.CountAsync();
            List<Category> items = await categories.OrderBy(c => c.Name).ThenBy(c => c.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Category>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _dbContext.Categories.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

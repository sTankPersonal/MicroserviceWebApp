using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Infrastructure.Persistence;

namespace RecipeMicroservice.Infrastructure.Repositories
{
    public class IngredientRepository(RecipeMicroserviceDbContext dbContext) : IIngredientRepository
    {
        private readonly RecipeMicroserviceDbContext _dbContext = dbContext;
        public async Task AddAsync(Ingredient entity)
        {
            _dbContext.Ingredients.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ingredient entity)
        {
            _dbContext.Ingredients.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<Ingredient>> GetAllAsync(FilterIngredient query)
        {
            IQueryable<Ingredient> ingredients = _dbContext.Ingredients.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                ingredients = ingredients.Where(i => EF.Functions.ILike(i.Name, $"%{query.SearchName}%"));
            }
            int totalItems = await ingredients.CountAsync();
            List<Ingredient> items = await ingredients.OrderBy(i => i.Name).ThenBy(i => i.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Ingredient>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<PagedResult<Ingredient>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Ingredient> ingredients = _dbContext.Ingredients.AsQueryable();
            int totalItems = await ingredients.CountAsync();
            List<Ingredient> items = await ingredients.OrderBy(i => i.Name).ThenBy(i => i.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Ingredient>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<Ingredient?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Ingredients.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateAsync(Ingredient entity)
        {
            _dbContext.Ingredients.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

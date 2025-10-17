using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Infrastructure.Persistence;

namespace RecipeMicroservice.Infrastructure.Repositories
{
    public class RecipeRepository(RecipeMicroserviceDbContext dbContext) : IRecipeRepository
    {
        private readonly RecipeMicroserviceDbContext _dbContext = dbContext;

        public async Task AddAsync(Recipe entity)
        {
            _dbContext.Recipes.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recipe entity)
        {
            _dbContext.Recipes.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PagedResult<Recipe>> GetAllAsync(FilterRecipe query)
        {
            IQueryable<Recipe> recipes = _dbContext.Recipes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                recipes = recipes.Where(r => r.Name.Contains(query.SearchName));
            }
            if (query.SearchPrepTimeInMinutes.HasValue)
            {
                recipes = recipes.Where(r => r.PrepTimeInMinutes == query.SearchPrepTimeInMinutes.Value);
            }
            if (query.SearchCookTimeInMinutes.HasValue)
            {
                recipes = recipes.Where(r => r.CookTimeInMinutes == query.SearchCookTimeInMinutes.Value);
            }
            if (query.SearchServings.HasValue)
            {
                recipes = recipes.Where(r => r.Servings == query.SearchServings.Value);
            }
            int totalItems = await recipes.CountAsync();
            List<Recipe> items = await recipes.OrderBy(r => r.Name).ThenBy(r => r.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Recipe>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<PagedResult<Recipe>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Recipe> recipes = _dbContext.Recipes.AsQueryable();
            int totalItems = await recipes.CountAsync();
            List<Recipe> items = await recipes.OrderBy(r => r.Name).ThenBy(r => r.Id).Skip(query.Skip).Take(query.Take).ToListAsync();
            return new PagedResult<Recipe>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<Recipe?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Recipe entity)
        {
            _dbContext.Recipes.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
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
            IQueryable<Recipe> recipes = _dbContext.Recipes
                .Include(r => r.RecipeCategories).ThenInclude(rc => rc.Category)
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                .AsSplitQuery()
                .Where(r => string.IsNullOrWhiteSpace(query.SearchName) || r.Name.Contains(query.SearchName))
                .Where(r => string.IsNullOrWhiteSpace(query.SearchCategories) || r.RecipeCategories.Any(rc => rc.Category.Name.Contains(query.SearchCategories)))
                .Where(r => string.IsNullOrWhiteSpace(query.SearchIngredients) || r.RecipeIngredients.Any(ri => ri.Ingredient.Name.Contains(query.SearchIngredients)));

            int totalItems = await recipes.CountAsync();
            List<Recipe> items = await recipes
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync();

            return new PagedResult<Recipe>(items, totalItems, query.PageNumber, query.PageSize);
        }

        public async Task<PagedResult<Recipe>> GetAllAsync(PagedQuery query)
        {
            IQueryable<Recipe> recipes = _dbContext.Recipes.AsQueryable();

            int totalItems = await recipes.CountAsync();
            List<Recipe> items = await recipes
                .OrderBy(r => r.Name)
                .ThenBy(r => r.Id)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync();

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

        // Instruction related methods
        public async Task<PagedResult<Instruction>> GetAllInstructionsAsync(Recipe recipe, PagedQuery query)
        {
            IQueryable<Instruction> instructions = recipe.Instructions.AsQueryable();

            int totalItems = await instructions.CountAsync();
            List<Instruction> items = await instructions
                .OrderBy(i => i.StepNumber)
                .ThenBy(i => i.Id)
                .Skip(query.Skip)
                .Take(query.Take)
                .ToListAsync();
            return new PagedResult<Instruction>(items, totalItems, query.PageNumber, query.PageSize);
        }
        public async Task<PagedResult<Instruction>> GetAllInstructionsAsync(Recipe recipe, FilterInstruction filter)
        {
            IQueryable<Instruction> instructions = recipe.Instructions.AsQueryable()
                .Where(i => string.IsNullOrWhiteSpace(filter.searchDescription) || i.Description.Contains(filter.searchDescription));
            int totalItems = await instructions.CountAsync();
            List<Instruction> items = await instructions
                .OrderBy(i => i.StepNumber)
                .ThenBy(i => i.Id)
                .Skip(filter.Skip)
                .Take(filter.Take)
                .ToListAsync();
            return new PagedResult<Instruction>(items, totalItems, filter.pageNumber, filter.pageSize);
        }
        public async Task<Instruction?> GetInstructionByIdAsync(Recipe recipe, Guid instructionId)
        {
            return await _dbContext.Recipes
                .Include(r => r.Instructions)
                .Where(r => r.Id == recipe.Id)
                .SelectMany(r => r.Instructions)
                .FirstOrDefaultAsync(i => i.Id == instructionId);
        }
        public async Task AddInstructionAsync(Recipe recipe, Instruction instruction)
        {
            recipe.Instructions.Add(instruction);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateInstructionAsync(Recipe recipe, Instruction instruction)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteInstructionByIdAsync(Recipe recipe, Instruction instruction)
        {
            recipe.Instructions.Remove(instruction);
            await _dbContext.SaveChangesAsync();
        }
    }
}

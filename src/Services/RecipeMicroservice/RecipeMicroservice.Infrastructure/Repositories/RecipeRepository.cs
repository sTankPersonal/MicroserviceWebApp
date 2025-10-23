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
                .AsSplitQuery();

            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                recipes = recipes.Where(r => EF.Functions.ILike(r.Name, $"%{query.SearchName}%"));
            }
            if (!string.IsNullOrWhiteSpace(query.SearchCategories))
            {
                recipes = recipes.Where(r => r.RecipeCategories.Any(rc =>
                    EF.Functions.ILike(rc.Category.Name, $"%{query.SearchCategories}%")));
            }
            if (!string.IsNullOrWhiteSpace(query.SearchIngredients))
            {
                recipes = recipes.Where(r => r.RecipeIngredients.Any(ri =>
                    EF.Functions.ILike(ri.Ingredient.Name, $"%{query.SearchIngredients}%")));
            }

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
        //public async Task<PagedResult<RecipeInstruction>> GetAllInstructionsAsync(Recipe recipe, PagedQuery query)
        //{
        //    IQueryable<RecipeInstruction> instructions = recipe.RecipeInstructions.AsQueryable();

        //    int totalItems = await instructions.CountAsync();
        //    List<RecipeInstruction> items = await instructions
        //        .OrderBy(i => i.StepNumber)
        //        .ThenBy(i => i.Id)
        //        .Skip(query.Skip)
        //        .Take(query.Take)
        //        .ToListAsync();
        //    return new PagedResult<RecipeInstruction>(items, totalItems, query.PageNumber, query.PageSize);
        //}
        //public async Task<PagedResult<RecipeInstruction>> GetAllInstructionsAsync(Recipe recipe, FilterInstruction filter)
        //{
        //    IQueryable<RecipeInstruction> instructions = recipe.RecipeInstructions.AsQueryable()
        //        .Where(i => string.IsNullOrWhiteSpace(filter.searchDescription) || i.Description.Contains(filter.searchDescription));
        //    int totalItems = await instructions.CountAsync();
        //    List<RecipeInstruction> items = await instructions
        //        .OrderBy(i => i.StepNumber)
        //        .ThenBy(i => i.Id)
        //        .Skip(filter.Skip)
        //        .Take(filter.Take)
        //        .ToListAsync();
        //    return new PagedResult<RecipeInstruction>(items, totalItems, filter.pageNumber, filter.pageSize);
        //}
        //public async Task<RecipeInstruction?> GetInstructionByIdAsync(Recipe recipe, Guid instructionId)
        //{
        //    return await _dbContext.Recipes
        //        .Include(r => r.RecipeInstructions)
        //        .Where(r => r.Id == recipe.Id)
        //        .SelectMany(r => r.RecipeInstructions)
        //        .FirstOrDefaultAsync(i => i.Id == instructionId);
        //}
        public async Task AddInstructionAsync(Recipe recipe, RecipeInstruction recipeInstruction)
        {
            recipe.RecipeInstructions.Add(recipeInstruction);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateInstructionAsync(Recipe recipe, RecipeInstruction recipeInstruction)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteInstructionByIdAsync(Recipe recipe, RecipeInstruction recipeInstruction)
        {
            recipe.RecipeInstructions.Remove(recipeInstruction);
            await _dbContext.SaveChangesAsync();
        }

        // Ingredient related methods
        public async Task AddIngredientAsync(Recipe recipe, RecipeIngredient recipeIngredient)
        {
            recipe.RecipeIngredients.Add(recipeIngredient);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateInstructionAsync(Recipe recipe, RecipeIngredient recipeIngredient)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteIngredientByIdAsync(Recipe recipe, RecipeIngredient recipeIngredient)
        {
            recipe.RecipeIngredients.Remove(recipeIngredient);
            await _dbContext.SaveChangesAsync();
        }

        // Category related methods
        public async Task AddCategoryAsync(Recipe recipe, RecipeCategory recipeCategory)
        {
            recipe.RecipeCategories.Add(recipeCategory);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateCategoryAsync(Recipe recipe, RecipeCategory recipeCategory)
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCategoryByIdAsync(Recipe recipe, RecipeCategory recipeCategory)
        {
            recipe.RecipeCategories.Remove(recipeCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}

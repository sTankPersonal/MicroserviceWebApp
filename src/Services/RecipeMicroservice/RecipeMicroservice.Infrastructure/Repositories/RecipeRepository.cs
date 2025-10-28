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
            if (query.SearchCategoryId.HasValue)
            {
                recipes = recipes.Where(r => r.RecipeCategories.Any(rc =>
                    rc.CategoryId == query.SearchCategoryId.Value));
            }
            if (query.SearchIngredientId.HasValue)
            {
                recipes = recipes.Where(r => r.RecipeIngredients.Any(ri =>
                    ri.IngredientId == query.SearchIngredientId.Value));
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
            IQueryable<Recipe> recipes = _dbContext.Recipes
                .Include(r => r.RecipeCategories).ThenInclude(rc => rc.Category)
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                .AsSplitQuery();

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
            return await _dbContext.Recipes
                .Include(r => r.RecipeCategories).ThenInclude(rc => rc.Category)
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeIngredients).ThenInclude(ri => ri.Unit)
                .Include(r => r.RecipeInstructions)
                .AsSplitQuery()
                .FirstOrDefaultAsync(r => r.Id == id);
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
        // Instructions
        public async Task AddRecipeInstructionAsync(Recipe recipe, RecipeInstruction recipeInstruction)
        {
            _dbContext.Attach(recipe);
            recipe.RecipeInstructions.Add(recipeInstruction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecipeInstructionAsync(Recipe recipe, RecipeInstruction recipeInstruction)
        {
            _dbContext.Entry(recipeInstruction).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecipeInstructionByIdAsync(Recipe recipe, RecipeInstruction recipeInstruction)
        {
            _dbContext.Attach(recipe);
            recipe.RecipeInstructions.Remove(recipeInstruction);
            await _dbContext.SaveChangesAsync();
        }

        // Ingredients
        public async Task AddRecipeIngredientAsync(Recipe recipe, RecipeIngredient recipeIngredient)
        {
            _dbContext.Attach(recipe);
            recipe.RecipeIngredients.Add(recipeIngredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecipeIngredientAsync(Recipe recipe, RecipeIngredient recipeIngredient)
        {
            _dbContext.Entry(recipeIngredient).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecipeIngredientByIdAsync(Recipe recipe, RecipeIngredient recipeIngredient)
        {
            _dbContext.Attach(recipe);
            recipe.RecipeIngredients.Remove(recipeIngredient);
            await _dbContext.SaveChangesAsync();
        }

        // Categories
        public async Task AddRecipeCategoryAsync(Recipe recipe, RecipeCategory recipeCategory)
        {
            _dbContext.Attach(recipe);
            recipe.RecipeCategories.Add(recipeCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecipeCategoryAsync(Recipe recipe, RecipeCategory recipeCategory)
        {
            _dbContext.Entry(recipeCategory).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecipeCategoryByIdAsync(Recipe recipe, RecipeCategory recipeCategory)
        {
            _dbContext.Attach(recipe);
            recipe.RecipeCategories.Remove(recipeCategory);
            await _dbContext.SaveChangesAsync();
        }

    }
}

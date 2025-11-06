using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.EntityFrameworkCore;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Infrastructure.Persistence;

namespace RecipeMicroservice.Infrastructure.Persistence.Repositories
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

            return new PagedResult<Recipe>() { Items = items, TotalItems = totalItems, PageNumber = query.PageNumber, PageSize = query.PageSize };
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

        // Photos
        public async Task AddRecipePhotoAsync(Recipe recipe, Photo photo)
        {
            _dbContext.Attach(recipe);
            recipe.Photos.Add(photo);
            await _dbContext.SaveChangesAsync();
        }

    }
}

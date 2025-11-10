using BuildingBlocks.SharedKernel.InfrastructureServices;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe, Guid, FilterRecipe>
    {
        Task AddRecipeInstructionAsync(Recipe recipe, RecipeInstruction instruction);
        Task UpdateRecipeInstructionAsync(Recipe recipe, RecipeInstruction instruction);
        Task DeleteRecipeInstructionByIdAsync(Recipe recipe, RecipeInstruction instruction);

        // Aggregate Child - Ingredients
        Task AddRecipeIngredientAsync(Recipe recipe, RecipeIngredient ingredient);
        Task UpdateRecipeIngredientAsync(Recipe recipe, RecipeIngredient ingredient);
        Task DeleteRecipeIngredientByIdAsync(Recipe recipe, RecipeIngredient ingredient);

        // Aggregate Child - Categories
        Task AddRecipeCategoryAsync(Recipe recipe, RecipeCategory category);
        Task UpdateRecipeCategoryAsync(Recipe recipe, RecipeCategory category);
        Task DeleteRecipeCategoryByIdAsync(Recipe recipe, RecipeCategory category);

        // Aggregate Child - Photos
        Task AddRecipePhotoAsync(Recipe recipe, Photo photo);
    }
}

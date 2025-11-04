using BuildingBlocks.SharedKernel.InfrastructureServices;
using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<PagedResult<Recipe>> GetAllAsync(FilterRecipe query);

        //Aggregate Child - Instructions
        //Task<PagedResult<Instruction>> GetAllInstructionsAsync(Recipe recipe, PagedQuery query);
        //Task<PagedResult<Instruction>> GetAllInstructionsAsync(Recipe recipe, FilterInstruction filter);
        //Task<Instruction?> GetInstructionByIdAsync(Recipe recipe, Guid instructionId);
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

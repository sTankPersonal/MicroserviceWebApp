using BuildingBlocks.SharedKernel.Repositories;
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
        Task AddInstructionAsync(Recipe recipe, RecipeInstruction instruction);
        Task UpdateInstructionAsync(Recipe recipe, RecipeInstruction instruction);
        Task DeleteInstructionByIdAsync(Recipe recipe, RecipeInstruction instruction);

        // Aggregate Child - Ingredients
        Task AddIngredientAsync(Recipe recipe, RecipeIngredient ingredient);
        Task UpdateInstructionAsync(Recipe recipe, RecipeIngredient ingredient);
        Task DeleteIngredientByIdAsync(Recipe recipe, RecipeIngredient ingredient);

        // Aggregate Child - Categories
        Task AddCategoryAsync(Recipe recipe, RecipeCategory category);
        Task UpdateCategoryAsync(Recipe recipe, RecipeCategory category);
        Task DeleteCategoryByIdAsync(Recipe recipe, RecipeCategory category);
    }
}

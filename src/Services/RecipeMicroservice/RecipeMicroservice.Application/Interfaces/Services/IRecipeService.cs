using BuildingBlocks.SharedKernel.DomainServices;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IRecipeService : IBasicCrudService<Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto, FilterRecipe>
    {

        public Task<Guid> CreateRecipeInstructionAsync(Guid recipeId, CreateRecipeInstructionDto dto);
        public Task UpdateRecipeInstructionAsync(Guid recipeId, Guid recipeInstructionId, UpdateRecipeInstructionDto dto);
        public Task DeleteRecipeInstructionAsync(Guid recipeId,  Guid recipeInstructionId);
        //Aggregate Child - RecipeIngredients
        public Task<Guid> CreateRecipeIngredientAsync(Guid recipeId, Guid ingredientId, CreateRecipeIngredientDto dto);
        public Task UpdateRecipeIngredientAsync(Guid recipeId, Guid recipeIngredientId, UpdateRecipeIngredientDto dto);
        public Task DeleteRecipeIngredientAsync(Guid recipeId,  Guid recipeIngredientId);

        //Aggregate Child - RecipeCategories
        public Task<Guid> CreateRecipeCategoryAsync(Guid recipeId, Guid categoryId, CreateRecipeCategoryDto dto);
        public Task UpdateRecipeCategoryAsync(Guid recipeId, Guid recipeCategoryId, UpdateRecipeCategoryDto dto);
        public Task DeleteRecipeCategoryAsync(Guid recipeId,  Guid recipeCategoryId);
    }
}

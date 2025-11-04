using BuildingBlocks.SharedKernel.Utils;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Mappers;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;
using BuildingBlocks.SharedKernel.DomainServices;

namespace RecipeMicroservice.Application.Services
{
    public class RecipeService(IRecipeRepository recipeRepository) : BasicAggregateCrudService<Recipe, Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto, FilterRecipe>(recipeRepository), IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;

        protected override Recipe ToEntity(CreateRecipeDto dto) => dto.ToEntity();
        protected override void ToEntity(UpdateRecipeDto dto, Recipe entity) => _ = dto.ToEntity(entity);
        protected override RecipeDto ToDto(Recipe entity) => entity.ToDto();

        public Task<Guid> CreateRecipeInstructionAsync(Guid recipeId, CreateRecipeInstructionDto dto)
            => AddChildAsync<RecipeInstruction, Guid, CreateRecipeInstructionDto>(recipeId, d => d.ToEntity(), _recipeRepository.AddRecipeInstructionAsync, dto);
        

        public Task UpdateRecipeInstructionAsync(Guid recipeId, Guid instructionId, UpdateRecipeInstructionDto dto)
            => UpdateChildAsync(recipeId, instructionId, r => r.RecipeInstructions, (d, i) => d.ToEntity(i), _recipeRepository.UpdateRecipeInstructionAsync, dto);

        public Task DeleteRecipeInstructionAsync(Guid recipeId, Guid instructionId)
            => DeleteChildAsync(recipeId, instructionId, r => r.RecipeInstructions, _recipeRepository.DeleteRecipeInstructionByIdAsync);

        public Task<Guid> CreateRecipeIngredientAsync(Guid recipeId, Guid categoryId, CreateRecipeIngredientDto dto)
            => AddChildAsync<RecipeIngredient, Guid, CreateRecipeIngredientDto>(recipeId, d => d.ToEntity(), _recipeRepository.AddRecipeIngredientAsync, dto);

        public Task UpdateRecipeIngredientAsync(Guid recipeId, Guid ingredientId, UpdateRecipeIngredientDto dto)
            => UpdateChildAsync(recipeId, ingredientId, r => r.RecipeIngredients, (d, i) => d.ToEntity(i), _recipeRepository.UpdateRecipeIngredientAsync, dto);

        public Task DeleteRecipeIngredientAsync(Guid recipeId, Guid ingredientId)
            => DeleteChildAsync(recipeId, ingredientId, r => r.RecipeIngredients, _recipeRepository.DeleteRecipeIngredientByIdAsync);

        public Task<Guid> CreateRecipeCategoryAsync(Guid recipeId, CreateRecipeCategoryDto dto)
            => AddChildAsync<RecipeCategory, Guid, CreateRecipeCategoryDto>(recipeId, d => d.ToEntity(), _recipeRepository.AddRecipeCategoryAsync, dto);

        public Task UpdateRecipeCategoryAsync(Guid recipeId, Guid categoryId, UpdateRecipeCategoryDto dto)
            => UpdateChildAsync(recipeId, categoryId, r => r.RecipeCategories, (d, c) => d.ToEntity(c), _recipeRepository.UpdateRecipeCategoryAsync, dto);

        public Task DeleteRecipeCategoryAsync(Guid recipeId, Guid categoryId)
            => DeleteChildAsync(recipeId, categoryId, r => r.RecipeCategories, _recipeRepository.DeleteRecipeCategoryByIdAsync);
    }
}

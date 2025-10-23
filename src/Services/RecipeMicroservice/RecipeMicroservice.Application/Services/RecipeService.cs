using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Application.DTOs.Instruction;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Aggregates;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
{
    public class RecipeService(IRecipeRepository recipeRepository) : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;
        public async Task<Guid> CreateAsync(CreateRecipeDto dto)
        {
            Recipe recipe = new()
            {
                Name = dto.Name,
                PrepTimeInMinutes = dto.PrepTimeInMinutes,
                CookTimeInMinutes = dto.CookTimeInMinutes,
                Servings = dto.Servings
            };
            await _recipeRepository.AddAsync(recipe);
            return recipe.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            Recipe recipe = await _recipeRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Recipe with id {id} not found.");
            await _recipeRepository.DeleteAsync(recipe);
        }

        public async Task<PagedResult<RecipeDto>> GetAllAsync(FilterRecipe filter)
        {
            PagedResult<Recipe> pagedRecipes =  await _recipeRepository.GetAllAsync(filter);
            List<RecipeDto> recipeDtos = [.. pagedRecipes.Items
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    PrepTimeInMinutes = r.PrepTimeInMinutes,
                    CookTimeInMinutes = r.CookTimeInMinutes,
                    Servings = r.Servings
                })];
            return new PagedResult<RecipeDto>(
                recipeDtos,
                pagedRecipes.TotalItems,
                pagedRecipes.PageNumber,
                pagedRecipes.PageSize);
        }

        public async Task<PagedResult<RecipeDto>> GetAllAsync(PagedQuery query)
        {
            PagedResult<Recipe> pagedRecipes =  await _recipeRepository.GetAllAsync(query);
            List<RecipeDto> recipeDtos = [.. pagedRecipes.Items
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    PrepTimeInMinutes = r.PrepTimeInMinutes,
                    CookTimeInMinutes = r.CookTimeInMinutes,
                    Servings = r.Servings
                })];
            return new PagedResult<RecipeDto>(
                recipeDtos,
                pagedRecipes.TotalItems,
                pagedRecipes.PageNumber,
                pagedRecipes.PageSize);
        }

        public async Task<RecipeDto?> GetByIdAsync(Guid id)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null)
            {
                return null;
            }
            return new RecipeDto
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PrepTimeInMinutes = recipe.PrepTimeInMinutes,
                CookTimeInMinutes = recipe.CookTimeInMinutes,
                Servings = recipe.Servings
            };
        }

        public async Task UpdateAsync(Guid id, UpdateRecipeDto dto)
        {
            Recipe recipe = await _recipeRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Recipe with id {id} not found.");
            recipe.Name = dto.Name;
            recipe.PrepTimeInMinutes = dto.PrepTimeInMinutes;
            recipe.CookTimeInMinutes = dto.CookTimeInMinutes;
            recipe.Servings = dto.Servings;
            await _recipeRepository.UpdateAsync(recipe);
        }

        // Aggregate Child - Instructions
        //public async Task<RecipeInstructionDto?> GetInstructionByIdAsync(Guid recipeId, Guid instructionId)
        //{
        //    Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
        //    RecipeInstruction? instruction = await _recipeRepository.GetInstructionByIdAsync(recipe, instructionId) ?? throw new KeyNotFoundException($"Instruction with id {instructionId} not found in Recipe with id {recipeId}.");
        //    return new RecipeInstructionDto
        //    {
        //        Id = instruction.Id,
        //        StepNumber = instruction.StepNumber,
        //        Description = instruction.Description
        //    };
        //}
        //public async Task<PagedResult<RecipeInstructionDto>> GetAllInstructionsAsync(Guid recipeId, PagedQuery query)
        //{
        //    Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
        //    PagedResult<Instruction> pagedInstructions =  await _recipeRepository.GetAllInstructionsAsync(recipe, query);
        //    List<RecipeInstructionDto> instructionDtos = [.. pagedInstructions.Items
        //        .Select(i => new RecipeInstructionDto
        //        {
        //            Id = i.Id,
        //            StepNumber = i.StepNumber,
        //            Description = i.Description
        //        })];
        //    return new PagedResult<RecipeInstructionDto>(
        //        instructionDtos,
        //        pagedInstructions.TotalItems,
        //        pagedInstructions.PageNumber,
        //        pagedInstructions.PageSize);
        //}
        //public async Task<PagedResult<RecipeInstructionDto>> GetAllInstructionsAsync(Guid recipeId, FilterInstruction filter)
        //{
        //    Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
        //    PagedResult<Instruction> pagedInstructions =  await _recipeRepository.GetAllInstructionsAsync(recipe, filter);
        //    List<RecipeInstructionDto> instructionDtos = [.. pagedInstructions.Items
        //        .Select(i => new RecipeInstructionDto
        //        {
        //            Id = i.Id,
        //            StepNumber = i.StepNumber,
        //            Description = i.Description
        //        })];
        //    return new PagedResult<RecipeInstructionDto>(
        //        instructionDtos,
        //        pagedInstructions.TotalItems,
        //        pagedInstructions.PageNumber,
        //        pagedInstructions.PageSize);
        //}
        public async Task<Guid> CreateInstructionAsync(Guid recipeId, CreateRecipeInstructionDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeInstruction instruction = new()
            {
                StepNumber = dto.StepNumber,
                Description = dto.Description,
                RecipeId = recipe.Id,
                Recipe = recipe
            };
            await _recipeRepository.AddInstructionAsync(recipe, instruction);
            return instruction.Id;
        }
        public async Task UpdateInstructionAsync(Guid recipeId, Guid instructionId, UpdateRecipeInstructionDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeInstruction? instruction = recipe.RecipeInstructions.FirstOrDefault(i => i.Id == instructionId) ?? throw new KeyNotFoundException($"Instruction with id {instructionId} not found in Recipe with id {recipeId}.");
            instruction.StepNumber = dto.StepNumber;
            instruction.Description = dto.Description;
            await _recipeRepository.UpdateInstructionAsync(recipe, instruction);
        }
        public async Task DeleteInstructionAsync(Guid recipeId, Guid instructionId)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeInstruction? instruction = recipe.RecipeInstructions.FirstOrDefault(i => i.Id == instructionId) ?? throw new KeyNotFoundException($"Instruction with id {instructionId} not found in Recipe with id {recipeId}.");
            await _recipeRepository.DeleteInstructionByIdAsync(recipe, instruction);
        }
    }
}

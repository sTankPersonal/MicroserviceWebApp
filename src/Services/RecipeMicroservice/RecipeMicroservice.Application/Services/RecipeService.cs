using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
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
            PagedResult<Recipe> pagedRecipes = await _recipeRepository.GetAllAsync(filter);
            List<RecipeDto> recipeDtos = [.. pagedRecipes.Items
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    PrepTimeInMinutes = r.PrepTimeInMinutes,
                    CookTimeInMinutes = r.CookTimeInMinutes,
                    Servings = r.Servings,
                    Instructions = [.. r.RecipeInstructions
                    .Select(i => new RecipeInstructionDto
                    {
                        Id = i.Id,
                        StepNumber = i.StepNumber,
                        Description = i.Description
                    })],
                    Ingredients = [.. r.RecipeIngredients
                    .Select(ri => new RecipeIngredientDto
                        {
                            Id = ri.Id,
                            IngredientId = ri.IngredientId,
                            IngredientName = ri.Ingredient != null ? ri.Ingredient.Name : string.Empty,
                            Quantity = ri.Quantity,
                            UnitId = ri.UnitId,
                            UnitName = ri.Unit != null ? ri.Unit.Name : string.Empty
                        })],
                    Categories = [.. r.RecipeCategories
                    .Select(rc => new RecipeCategoryDto
                        {
                            Id = rc.Id,
                            CategoryId = rc.CategoryId,
                            CategoryName = rc.Category != null ? rc.Category.Name : string.Empty
                        })]
                    })];
            return new PagedResult<RecipeDto>(
                recipeDtos,
                pagedRecipes.TotalItems,
                pagedRecipes.PageNumber,
                pagedRecipes.PageSize);
        }

        public async Task<PagedResult<RecipeDto>> GetAllAsync(PagedQuery query)
        {
            PagedResult<Recipe> pagedRecipes = await _recipeRepository.GetAllAsync(query);
            List<RecipeDto> recipeDtos = [.. pagedRecipes.Items
                .Select(r => new RecipeDto
                {
                    Id = r.Id,
                    Name = r.Name,
                    PrepTimeInMinutes = r.PrepTimeInMinutes,
                    CookTimeInMinutes = r.CookTimeInMinutes,
                    Servings = r.Servings,
                    Instructions = [.. r.RecipeInstructions
                    .Select(i => new RecipeInstructionDto
                    {
                        Id = i.Id,
                        StepNumber = i.StepNumber,
                        Description = i.Description
                    })],
                    Ingredients = [.. r.RecipeIngredients
                    .Select(ri => new RecipeIngredientDto
                        {
                            Id = ri.Id,
                            IngredientId = ri.IngredientId,
                            IngredientName = ri.Ingredient != null ? ri.Ingredient.Name : string.Empty,
                            Quantity = ri.Quantity,
                            UnitId = ri.UnitId,
                            UnitName = ri.Unit != null ? ri.Unit.Name : string.Empty
                        })],
                    Categories = [.. r.RecipeCategories
                    .Select(rc => new RecipeCategoryDto
                        {
                            Id = rc.Id,
                            CategoryId = rc.CategoryId,
                            CategoryName = rc.Category != null ? rc.Category.Name : string.Empty
                        })]
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
                Servings = recipe.Servings,
                Instructions = [.. recipe.RecipeInstructions
                    .Select(i => new RecipeInstructionDto
                    {
                        Id = i.Id,
                        StepNumber = i.StepNumber,
                        Description = i.Description
                    })],
                Ingredients = [.. recipe.RecipeIngredients
                .Select(ri => new RecipeIngredientDto
                    {
                        Id = ri.Id,
                        IngredientId = ri.IngredientId,
                        IngredientName = ri.Ingredient != null ? ri.Ingredient.Name : string.Empty,
						Quantity = ri.Quantity,
                        UnitId = ri.UnitId,
                        UnitName = ri.Unit != null ? ri.Unit.Name : string.Empty
					})],
                Categories = [.. recipe.RecipeCategories
                .Select(rc => new RecipeCategoryDto
                    {
                        Id = rc.Id,
                        CategoryId = rc.CategoryId,
                        CategoryName = rc.Category != null ? rc.Category.Name : string.Empty
					})]
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
        public async Task<Guid> CreateRecipeInstructionAsync(Guid recipeId, CreateRecipeInstructionDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeInstruction instruction = new()
            {
                StepNumber = dto.StepNumber,
                Description = dto.Description,
                RecipeId = recipe.Id,
                Recipe = recipe
            };
            await _recipeRepository.AddRecipeInstructionAsync(recipe, instruction);
            return instruction.Id;
        }
        public async Task UpdateRecipeInstructionAsync(Guid recipeId, Guid instructionId, UpdateRecipeInstructionDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeInstruction? instruction = recipe.RecipeInstructions.FirstOrDefault(i => i.Id == instructionId) ?? throw new KeyNotFoundException($"Instruction with id {instructionId} not found in Recipe with id {recipeId}.");
            instruction.StepNumber = dto.StepNumber;
            instruction.Description = dto.Description;
            await _recipeRepository.UpdateRecipeInstructionAsync(recipe, instruction);
        }
        public async Task DeleteRecipeInstructionAsync(Guid recipeId, Guid instructionId)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeInstruction? instruction = recipe.RecipeInstructions.FirstOrDefault(i => i.Id == instructionId) ?? throw new KeyNotFoundException($"Instruction with id {instructionId} not found in Recipe with id {recipeId}.");
            await _recipeRepository.DeleteRecipeInstructionByIdAsync(recipe, instruction);
        }
        public async Task<Guid> CreateRecipeIngredientAsync(Guid recipeId, Guid ingredientId, CreateRecipeIngredientDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeIngredient recipeIngredient = new()
            {
                IngredientId = ingredientId,
                Quantity = dto.Quantity,
                UnitId = dto.UnitId,
                RecipeId = recipe.Id,
            };
            await _recipeRepository.AddRecipeIngredientAsync(recipe, recipeIngredient);
            return recipeIngredient.Id;
        }
        public async Task UpdateRecipeIngredientAsync(Guid recipeId, Guid recipeIngredientId, UpdateRecipeIngredientDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeIngredient? recipeIngredient = recipe.RecipeIngredients.FirstOrDefault(ri => ri.Id == recipeIngredientId) ?? throw new KeyNotFoundException($"RecipeIngredient with id {recipeIngredientId} not found in Recipe with id {recipeId}.");
            recipeIngredient.Quantity = dto.Quantity;
            recipeIngredient.UnitId = dto.UnitId;
            await _recipeRepository.UpdateRecipeIngredientAsync(recipe, recipeIngredient);
        }
        public async Task DeleteRecipeIngredientAsync(Guid recipeId, Guid recipeIngredientId)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeIngredient? recipeIngredient = recipe.RecipeIngredients.FirstOrDefault(ri => ri.Id == recipeIngredientId) ?? throw new KeyNotFoundException($"RecipeIngredient with id {recipeIngredientId} not found in Recipe with id {recipeId}.");
            await _recipeRepository.DeleteRecipeIngredientByIdAsync(recipe, recipeIngredient);
        }
        public async Task<Guid> CreateRecipeCategoryAsync(Guid recipeId, Guid categoryId, CreateRecipeCategoryDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeCategory recipeCategory = new()
            {
                CategoryId = categoryId,
                RecipeId = recipe.Id,
            };
            await _recipeRepository.AddRecipeCategoryAsync(recipe, recipeCategory);
            return recipeCategory.Id;
        }
        public async Task UpdateRecipeCategoryAsync(Guid recipeId, Guid recipeCategoryId, UpdateRecipeCategoryDto dto)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeCategory? recipeCategory = recipe.RecipeCategories.FirstOrDefault(rc => rc.Id == recipeCategoryId) ?? throw new KeyNotFoundException($"RecipeCategory with id {recipeCategoryId} not found in Recipe with id {recipeId}.");
            // No updatable fields in RecipeCategoryDto as of now
            await _recipeRepository.UpdateRecipeCategoryAsync(recipe, recipeCategory);
        }
        public async Task DeleteRecipeCategoryAsync(Guid recipeId, Guid recipeCategoryId)
        {
            Recipe? recipe = await _recipeRepository.GetByIdAsync(recipeId) ?? throw new KeyNotFoundException($"Recipe with id {recipeId} not found.");
            RecipeCategory? recipeCategory = recipe.RecipeCategories.FirstOrDefault(rc => rc.Id == recipeCategoryId) ?? throw new KeyNotFoundException($"RecipeCategory with id {recipeCategoryId} not found in Recipe with id {recipeId}.");
            await _recipeRepository.DeleteRecipeCategoryByIdAsync(recipe, recipeCategory);
        }
    }
}

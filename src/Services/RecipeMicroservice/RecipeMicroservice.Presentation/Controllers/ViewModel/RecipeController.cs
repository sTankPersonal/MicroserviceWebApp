using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Recipe;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Controllers.ViewModel
{
    /* RecipeController Returns a View model
     * GET: /Recipe/{id} - Get recipe by id and return Details view
     * GET: /Recipe - Get all recipes and return List view
     * GET: /Recipe/Create - Return Create view
     * GET: /Recipe/Edit/{id} - Get recipe by id and return Edit view
     * GET: /Recipe/Delete/{id} - Get recipe by id and return Delete view
     * 
     * POST: /Recipe/Create - Create a new recipe and redirect to Details view
     * POST: /Recipe/Edit/{id} - Update a recipe and redirect to Details view
     * POST: /Recipe/Delete/{id} - Delete a recipe and redirect to List view
     * 
     * POST: /Recipe/{id}/Instruction/Add/{instructionId} - Add an instruction to the recipe being created or edited
     * POST: /Recipe/{id}/Ingredient/Add/{ingredientId} - Add an ingredient to the recipe being created or edited
     * POST: /Recipe/{id}/Category/Add/{categoryId} - Add a category to the recipe being created or edited
     * 
     * POST: /Recipe/{id}/Instruction/Remove - Remove an instruction from the recipe being created or edited
     * POST: /Recipe/{id}/Ingredient/Remove - Remove an ingredient from the recipe being created or edited
     * POST: /Recipe/{id}/Category/Remove - Remove a category from the recipe being created or edited
     * 
     * POST: /Recipe/{id}/Instruction/Edit - Edit an instruction in the recipe being created or edited
     * POST: /Recipe/{id}/Ingredient/Edit - Edit an ingredient in the recipe being created or edited
     * POST: /Recipe/{id}/Category/Edit - Edit a category in the recipe being created or edited
     */
    [Route("[controller]")]
    public class RecipeController(IRecipeService recipeService) : Controller
    {
        private readonly IRecipeService _recipeService = recipeService;

        // GET: /Recipe/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            RecipeDto? recipe = await _recipeService.GetByIdAsync(id);
			if (recipe == null)
            {
                return NotFound();
            }
            return View("Details", RecipeViewModel.FromDto(recipe));
        }

        // GET: /Recipe
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllRecipes(ListRecipeViewModel listRecipeViewModel)
        {
            FilterRecipe filterRecipe = new(listRecipeViewModel.SearchName, listRecipeViewModel.SearchCategoryId, listRecipeViewModel.SearchIngredientId);
            PagedResult<RecipeDto> recipes = await _recipeService.GetAllAsync(filterRecipe);
            ListRecipeViewModel newListRecipeViewModel = ListRecipeViewModel.FromPagedResult(recipes);
            newListRecipeViewModel.SearchName = filterRecipe.SearchName;
            newListRecipeViewModel.SearchCategoryId = filterRecipe.SearchCategoryId;
            newListRecipeViewModel.SearchIngredientId = filterRecipe.SearchIngredientId;
            return View("List", newListRecipeViewModel);
        }

        // GET: /Recipe/Create
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateRecipe()
        {
            return View("Create", new CreateRecipeViewModel());
        }

        // GET: /Recipe/Edit/{id}
        [HttpGet("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditRecipe(Guid id)
        {
            RecipeDto? recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            EditAndAttachElementsRecipeViewModel viewModel = EditAndAttachElementsRecipeViewModel.FromDto(recipe);
            viewModel.NewInstruction.StepNumber = viewModel.Recipe.RecipeInstructions.Count + 1;
            return View("Edit", viewModel);
        }

        // GET: /Recipe/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            RecipeDto? recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View("Delete", RecipeViewModel.FromDto(recipe));
        }

        // POST: /Recipe/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateRecipe(CreateRecipeViewModel model)
        {
            CreateRecipeDto createRecipeDto = new()
            {
                Name = model.Name,
                PrepTimeInMinutes = model.PrepTimeInMinutes,
                CookTimeInMinutes = model.CookTimeInMinutes,
                Servings = model.Servings,
            };
            Guid newRecipeId = await _recipeService.CreateAsync(createRecipeDto);
            return RedirectToAction("Details", new { id = newRecipeId });
        }

        // POST: /Recipe/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditRecipe(Guid id, EditRecipeViewModel recipe)
        {
            UpdateRecipeDto updateRecipeDto = new()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PrepTimeInMinutes = recipe.PrepTimeInMinutes,
                CookTimeInMinutes = recipe.CookTimeInMinutes,
                Servings = recipe.Servings
            };
            await _recipeService.UpdateAsync(id, updateRecipeDto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Recipe/Delete/{id}
        [HttpPost("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecipeConfirmed(Guid id)
        {
            await _recipeService.DeleteAsync(id);
            return RedirectToAction("List");

        }

        // POST: /Recipe/{id}/Instruction/Add
        [HttpPost("{id}/Instruction/Add")]
        [ActionName("AddInstruction")]
        public async Task<IActionResult> AddInstruction(Guid id, CreateRecipeInstructionViewModel NewInstruction)
        {
            await _recipeService.CreateRecipeInstructionAsync(id, new CreateRecipeInstructionDto
            {
                Description = NewInstruction.Description,
                StepNumber = NewInstruction.StepNumber
            });
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Ingredient/Add
        [HttpPost("{id}/Ingredient/Add")]
        [ActionName("AddIngredient")]
        public async Task<IActionResult> AddIngredient(Guid id, CreateRecipeIngredientViewModel NewIngredient)
        {
            await _recipeService.CreateRecipeIngredientAsync(id, NewIngredient.IngredientId, new CreateRecipeIngredientDto
            {
                UnitId = NewIngredient.UnitId,
                Quantity = NewIngredient.Quantity
            });
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Category/Add
        [HttpPost("{id}/Category/Add")]
        [ActionName("AddCategory")]
        public async Task<IActionResult> AddCategory(Guid id, CreateRecipeCategoryViewModel NewCategory)
        {
            await _recipeService.CreateRecipeCategoryAsync(id, NewCategory.CategoryId, new CreateRecipeCategoryDto { });
            return RedirectToAction("Edit", new { id });
        }

        // POST: /Recipe/{id}/Instruction/Remove/{recipeInstructionId}
        [HttpPost("{id}/Instruction/Remove/{recipeInstructionId}")]
        [ActionName("RemoveInstruction")]
        public async Task<IActionResult> RemoveInstruction(Guid id, Guid recipeInstructionId)
        {
            await _recipeService.DeleteRecipeInstructionAsync(id, recipeInstructionId);
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Ingredient/Remove/{recipeIngredientId}
        [HttpPost("{id}/Ingredient/Remove/{recipeIngredientId}")]
        [ActionName("RemoveIngredient")]
        public async Task<IActionResult> RemoveIngredient(Guid id, Guid recipeIngredientId)
        {
            await _recipeService.DeleteRecipeIngredientAsync(id, recipeIngredientId);
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Category/Remove/{recipeCategoryId}
        [HttpPost("{id}/Category/Remove/{recipeCategoryId}")]
        [ActionName("RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(Guid id, Guid recipeCategoryId)
        {
            await _recipeService.DeleteRecipeCategoryAsync(id, recipeCategoryId);
            return RedirectToAction("Edit", new { id });
        }
    }
}

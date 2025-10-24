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
        public async Task<IActionResult> GetAllRecipes(FilterRecipe filterRecipe)
        {
            PagedResult<RecipeDto> recipes = await _recipeService.GetAllAsync(filterRecipe);
            return View("List", ListRecipeViewModel.FromPagedResult(recipes));
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
            return View("Edit", EditRecipeViewModel.FromDto(recipe));
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
        public async Task<IActionResult> EditRecipe(Guid id, EditRecipeViewModel model)
        {
            UpdateRecipeDto updateRecipeDto = new()
            {
                Id = model.Id,
                Name = model.Name,
                PrepTimeInMinutes = model.PrepTimeInMinutes,
                CookTimeInMinutes = model.CookTimeInMinutes,
                Servings = model.Servings
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
        public async Task<IActionResult> AddInstruction(Guid id, CreateRecipeInstructionViewModel createRecipeInstructionViewModel)
        {
            await _recipeService.CreateRecipeInstructionAsync(id, new CreateRecipeInstructionDto
            {
                Description = createRecipeInstructionViewModel.Description,
                StepNumber = createRecipeInstructionViewModel.StepNumber
            });
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Ingredient/Add
        [HttpPost("{id}/Ingredient/Add")]
        [ActionName("AddIngredient")]
        public async Task<IActionResult> AddIngredient(Guid id, CreateRecipeIngredientViewModel createRecipeIngredientViewModel)
        {
            await _recipeService.CreateRecipeIngredientAsync(id, createRecipeIngredientViewModel.IngredientId, new CreateRecipeIngredientDto
            {
                UnitId = createRecipeIngredientViewModel.UnitId,
                Quantity = createRecipeIngredientViewModel.Quantity
            });
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Category/Add
        [HttpPost("{id}/Category/Add")]
        public async Task<IActionResult> AddCategory(Guid id, CreateRecipeCategoryViewModel createRecipeCategoryViewModel)
        {
            Console.WriteLine("Adding category to recipe...");
            Console.WriteLine($"Recipe ID: {id}");
            Console.WriteLine($"Category ID: {createRecipeCategoryViewModel.CategoryId}");
            await _recipeService.CreateRecipeCategoryAsync(id, createRecipeCategoryViewModel.CategoryId, new CreateRecipeCategoryDto { });
            return RedirectToAction("Edit", new { id });
        }

        // POST: /Recipe/{id}/Instruction/Remove
        [HttpPost("{id}/Instruction/Remove")]
        public async Task<IActionResult> RemoveInstruction(Guid id, Guid instructionId)
        {
            await _recipeService.DeleteRecipeInstructionAsync(id, instructionId);
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Ingredient/Remove
        [HttpPost("{id}/Ingredient/Remove")]
        public async Task<IActionResult> RemoveIngredient(Guid id, Guid ingredientId)
        {
            await _recipeService.DeleteRecipeIngredientAsync(id, ingredientId);
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Category/Remove/{categoryId}
        [HttpPost("{id}/Category/Remove")]
        public async Task<IActionResult> RemoveCategory(Guid id, Guid categoryId)
        {
            await _recipeService.DeleteRecipeCategoryAsync(id, categoryId);
            return RedirectToAction("Edit", new { id });
        }
    }
}

using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Presentation.Mappers;
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
            RecipeDto? dto = await _recipeService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Details", dto.ToViewModel());
        }

        // GET: /Recipe
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllRecipes(FilterRecipeViewModel filter)
        {
            PagedResult<RecipeDto> dtos = await _recipeService.GetAllAsync(filter.ToFilter());
            return View("List", dtos.ToListViewModel().WithFilter(filter));
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
            RecipeDto? dto = await _recipeService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Edit", dto.ToUpdateAndAttachElementsViewModel());
        }

        // GET: /Recipe/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            RecipeDto? dto = await _recipeService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Delete", dto.ToViewModel());
        }

        // POST: /Recipe/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateRecipe(CreateRecipeViewModel viewModel)
        {
            CreateRecipeDto createRecipeDto = viewModel.ToCreateDto();
            Guid id = await _recipeService.CreateAsync(createRecipeDto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Recipe/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditRecipe(Guid id, UpdateRecipeViewModel updateRecipe)
        {
            UpdateRecipeDto updateRecipeDto = updateRecipe.ToUpdateDto();
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
        public async Task<IActionResult> AddInstruction(Guid id, [Bind(Prefix = "AttachElements.NewInstruction")] CreateRecipeInstructionViewModel NewInstruction)
        {
            await _recipeService.CreateRecipeInstructionAsync(id, NewInstruction.ToCreateDto());
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Ingredient/Add
        [HttpPost("{id}/Ingredient/Add")]
        [ActionName("AddIngredient")]
        public async Task<IActionResult> AddIngredient(Guid id, [Bind(Prefix = "AttachElements.NewIngredient")] CreateRecipeIngredientViewModel NewIngredient)
        {
            await _recipeService.CreateRecipeIngredientAsync(id, NewIngredient.ToCreateDto());
            return RedirectToAction("Edit", new { id });
        }
        // POST: /Recipe/{id}/Category/Add
        [HttpPost("{id}/Category/Add")]
        [ActionName("AddCategory")]
        public async Task<IActionResult> AddCategory(Guid id, [Bind(Prefix = "AttachElements.NewCategory")] CreateRecipeCategoryViewModel NewCategory)
        {
            await _recipeService.CreateRecipeCategoryAsync(id, NewCategory.ToCreateDto());
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

        //POST: /Recipe/{id}/Instruction/Edit/{recipeInstructionId}
        [HttpPost("{id}/Instruction/Edit/{recipeInstructionId}")]
        [ActionName("EditInstruction")]
        public async Task<IActionResult> EditInstruction(Guid id, Guid recipeInstructionId, [Bind(Prefix = "UpdateRecipe.RecipeInstructions")] UpdateRecipeInstructionViewModel updatedInstruction)
        {
            await _recipeService.UpdateRecipeInstructionAsync(id, recipeInstructionId, updatedInstruction.ToUpdateDto());
            return RedirectToAction("Edit", new { id });
        }

        //POST: /Recipe/{id}/Ingredient/Edit/{recipeIngredientId}
        [HttpPost("{id}/Ingredient/Edit/{recipeIngredientId}")]
        [ActionName("EditIngredient")]
        public async Task<IActionResult> EditIngredient(Guid id, Guid recipeIngredientId, [Bind(Prefix = "UpdateRecipe.RecipeIngredients")] UpdateRecipeIngredientViewModel updatedIngredient)
        {
            await _recipeService.UpdateRecipeIngredientAsync(id, recipeIngredientId, updatedIngredient.ToUpdateDto());
            return RedirectToAction("Edit", new { id });
        }
        //POST: /Recipe/{id}/Category/Edit/{recipeCategoryId}
        [HttpPost("{id}/Category/Edit/{recipeCategoryId}")]
        [ActionName("EditCategory")]
        public async Task<IActionResult> EditCategory(Guid id, Guid recipeCategoryId, [Bind(Prefix = "UpdateRecipe.RecipeCategories")] UpdateRecipeCategoryViewModel updatedCategory)
        {
            await _recipeService.UpdateRecipeCategoryAsync(id, recipeCategoryId, updatedCategory.ToUpdateDto());
            return RedirectToAction("Edit", new { id });
        }
    }
}

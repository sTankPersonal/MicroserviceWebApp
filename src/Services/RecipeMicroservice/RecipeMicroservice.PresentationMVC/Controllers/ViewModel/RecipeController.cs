using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.PresentationMVC.Models.Recipe;

namespace RecipeMicroservice.PresentationMVC.Controllers.ViewModel
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
    }
}

using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Ingredient;

namespace RecipeMicroservice.Presentation.Controllers.ViewModel
{
    /* GET: /Ingredient - Get all ingredients and return List view
     * GET: /Ingredient/{id} - Get ingredient by id and return Details view
     * GET: /Ingredient/Create - Return Create view
     * GET: /Ingredient/Edit/{id} - Get ingredient by id and return Edit view
     * GET: /Ingredient/Delete/{id} - Get ingredient by id and return Delete view
     * 
     * POST: /Ingredient/Create - Create a new ingredient and redirect to Details view
     * POST: /Ingredient/Edit/{id} - Update an ingredient and redirect to Details view
     * POST: /Ingredient/Delete/{id} - Delete an ingredient and redirect to List view
     */
    [Route("[controller]")]
    public class IngredientController(IIngredientService ingredientService) : Controller
    {
        private readonly IIngredientService _ingredientService = ingredientService;

        // GET: /Ingredient
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllIngredients(FilterIngredient filterIngredient)
        {
            PagedResult<IngredientDto> ingredients = await _ingredientService.GetAllAsync(filterIngredient);
            return View("List", ListIngredientViewModel.FromPagedResult(ingredients));
        }

        // GET: /Ingredient/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetIngredientById(Guid id)
        {
            IngredientDto? ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View("Details", IngredientViewModel.FromDto(ingredient));
        }

        // GET: /Ingredient/Create
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateIngredient()
        {
            return View("Create", new CreateIngredientViewModel());
        }

        // GET: /Ingredient/Edit/{id}
        [HttpGet("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditIngredient(Guid id)
        {
            IngredientDto? ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View("Edit", EditIngredientViewModel.FromDto(ingredient));
        }

        // GET: /Ingredient/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            IngredientDto? ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View("Delete", IngredientViewModel.FromDto(ingredient));
        }

        // POST: /Ingredient/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateIngredient(CreateIngredientViewModel model)
        {
            CreateIngredientDto dto = new ()
            {
                Name = model.Name
            };
            Guid newIngredientId = await _ingredientService.CreateAsync(dto);
            return RedirectToAction("Details", new { id = newIngredientId });
        }

        // POST: /Ingredient/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditIngredient(Guid id, EditIngredientViewModel model)
        {
            UpdateIngredientDto dto = new ()
            {
                Name = model.Name
            };
            await _ingredientService.UpdateAsync(id, dto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Ingredient/Delete/{id}
        [HttpPost("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteIngredientConfirmed(Guid id)
        {
            await _ingredientService.DeleteAsync(id);
            return RedirectToAction("List");
        }
    }
}

using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Presentation.Mappers;
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
        public async Task<IActionResult> GetAllIngredients(FilterIngredientViewModel filter)
        {
            PagedResult<IngredientDto> dtos = await _ingredientService.GetAllAsync(filter.ToFilter());
            return View("List", dtos.ToListViewModel().WithFilter(filter));
        }

        // GET: /Ingredient/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetIngredientById(Guid id)
        {
            IngredientDto? dto = await _ingredientService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Details", dto.ToViewModel());
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
            IngredientDto? dto = await _ingredientService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Edit", dto.ToUpdateViewModel());
        }

        // GET: /Ingredient/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            IngredientDto? dto = await _ingredientService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Delete", dto.ToViewModel());
        }

        // POST: /Ingredient/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateIngredient(CreateIngredientViewModel viewModel)
        {
            CreateIngredientDto dto = viewModel.ToCreateDto();
            Guid id = await _ingredientService.CreateAsync(dto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Ingredient/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditIngredient(Guid id, UpdateIngredientViewModel viewModel)
        {
            UpdateIngredientDto dto = viewModel.ToUpdateDto();
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

using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Ingredient;

namespace RecipeMicroservice.Presentation.Controllers.Mvc
{
    [Route("[controller]")]
    public class IngredientController(IIngredientService ingredientService) : Controller
    {
        private readonly IIngredientService _ingredientService = ingredientService;

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
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllIngredients()
        {
            PagedResult<IngredientDto> ingredients = await _ingredientService.GetAllAsync(new FilterIngredient());
            return View("List", IngredientListViewModel.FromPagedResult(ingredients));
        }
        [HttpGet("PartialIngredients")]
        public async Task<IActionResult> GetPartialIngredientList(string? searchName = null, int pageNumber = 1, int pageSize = 10)
        {
            FilterIngredient filterIngredient = new(searchName, pageNumber, pageSize);
            PagedResult<IngredientDto> ingredients = await _ingredientService.GetAllAsync(filterIngredient);
            return PartialView("_IngredientListPartial", IngredientListViewModel.FromPagedResult(ingredients));
        }
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateIngredient()
        {
            return View("Create", new CreateIngredientViewModel());
        }
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> Create(CreateIngredientViewModel createIngredientViewModel)
        {
            CreateIngredientDto createIngredientDto = new()
            {
                Name = createIngredientViewModel.Name,
            };
            Guid id = await _ingredientService.CreateAsync(createIngredientDto);
            return RedirectToAction("Details", new { id });
        }
    }
}

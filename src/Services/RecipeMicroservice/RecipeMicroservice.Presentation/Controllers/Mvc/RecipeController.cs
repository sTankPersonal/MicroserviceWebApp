using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;


namespace RecipeMicroservice.Presentation.Controllers.Mvc
{
    [Route("[controller]")]
    public class RecipeController(IRecipeService recipeService, ICategoryService categoryService) : Controller
    {
        private readonly IRecipeService _recipeService = recipeService;
        private readonly ICategoryService _categoryService = categoryService;

        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            RecipeDto? recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View("Details", recipe);
        }
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllRecipes(string? searchName = null, string? searchIngredient = null, string? searchCategory = null, int pageNumber = 1, int pageSize = 10)
        {
            Console.WriteLine("Temp");
            FilterRecipe filterRecipe = new(searchName, searchIngredient, searchCategory, pageNumber, pageSize);
            PagedResult<RecipeDto> recipes = await _recipeService.GetAllAsync(filterRecipe);
            ViewData["SearchName"] = searchName;
            ViewData["SearchIngredient"] = searchIngredient;
            ViewData["SearchCategory"] = searchCategory;
            return View("List", recipes);

        }
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateRecipe()
        {
            return View("Create", new CreateRecipeDto());
        }
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> Create(CreateRecipeDto recipeCreateDto)
        {
            await _recipeService.CreateAsync(recipeCreateDto);
            return RedirectToAction("GetAllRecipes");
        }

        [HttpGet("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditRecipe(Guid id)
        {
            RecipeDto? recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            UpdateRecipeDto updateRecipeDto = new()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                PrepTimeInMinutes = recipe.PrepTimeInMinutes,
                CookTimeInMinutes = recipe.CookTimeInMinutes,
                Servings = recipe.Servings,
                Instructions = recipe.Instructions,
                Ingredients = recipe.Ingredients,
                Categories = recipe.Categories
            };

            ViewData["AllCategories"] = await _categoryService.GetAllAsync();
            return View("Edit", updateRecipeDto);
        }
    }
}

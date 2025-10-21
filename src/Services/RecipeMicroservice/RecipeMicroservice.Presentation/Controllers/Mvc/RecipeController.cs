using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Recipe;



namespace RecipeMicroservice.Presentation.Controllers.Mvc
{
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
        public async Task<IActionResult> GetAllRecipes()
        {
            PagedResult<RecipeDto> recipes = await _recipeService.GetAllAsync(new FilterRecipe());
            return View("List", RecipeListViewModel.FromPagedResult(recipes));
        }
        [HttpGet("PartialRecipes")]
        public async Task<IActionResult> GetPartialRecipeList(string? searchName = null, string? searchIngredient = null, string? searchCategory = null, int pageNumber = 1, int pageSize = 10)
        {
            FilterRecipe filterRecipe = new(searchName, searchIngredient, searchCategory, pageNumber, pageSize);
            PagedResult<RecipeDto> recipes = await _recipeService.GetAllAsync(filterRecipe);
            return PartialView("_RecipeListPartial", RecipeListViewModel.FromPagedResult(recipes));
        }

        // GET: /Recipe/Create
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateRecipe()
        {
            return View("Create", new CreateRecipeViewModel());
        }
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> Create(CreateRecipeViewModel createRecipeViewModel)
        {
            CreateRecipeDto createRecipeDto = new()
            {
                Name = createRecipeViewModel.Name,
                PrepTimeInMinutes = createRecipeViewModel.PrepTimeInMinutes,
                CookTimeInMinutes = createRecipeViewModel.CookTimeInMinutes,
                Servings = createRecipeViewModel.Servings,
            };
            Guid id = await _recipeService.CreateAsync(createRecipeDto);
            return RedirectToAction("Details", new { id });
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

            return View("Edit", updateRecipeDto);
        }

        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(Guid id, UpdateRecipeDto updateRecipeDto)
        {
            if (id != updateRecipeDto.Id)
            {
                return BadRequest();
            }
            await _recipeService.UpdateAsync(id, updateRecipeDto);
            return RedirectToAction("Details", new { id });
        }
    }
}

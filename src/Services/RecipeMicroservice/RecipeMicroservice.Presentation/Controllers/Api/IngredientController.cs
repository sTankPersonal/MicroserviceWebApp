using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController(IIngredientService ingredientService) : ControllerBase
    {
        private readonly IIngredientService _ingredientService = ingredientService;

        // GET: api/Ingredient/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetIngredientById(Guid id)
        {
            IngredientDto? ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        // GET: api/Ingredient
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllIngredients(string? searchName = null, int pageNumber = 1, int pageSize = 10)
        {
            PagedResult<IngredientDto> ingredients = await _ingredientService.GetAllAsync(new FilterIngredient(searchName, pageNumber, pageSize));
            return Ok(ingredients);
        }
    }
}

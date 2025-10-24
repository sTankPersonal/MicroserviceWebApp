using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Application.DTOs.Recipe;

namespace RecipeMicroservice.PresentationMVC.Controllers.Api
{
    [Route("api/[Controller]")]
    public class RecipeController(IRecipeService recipeService) : ControllerBase
    {
        private readonly IRecipeService _recipeService = recipeService;
        // GET api/Recipe/AjaxList
        [HttpGet("Ajax")]
        public async Task<IActionResult> AjaxGetAll(FilterRecipe filterRecipe)
        {
            PagedResult<RecipeDto> recipes = await _recipeService.GetAllAsync(filterRecipe);
            AjaxReturnDto result = new()
            {
                results = [..recipes.Items.Select(r => new AjaxResultDto
                {
                    id = r.Id.ToString(),
                    text = r.Name
                })],
                pagination = new AjaxPaginationDto
                {
                    more = recipes.PageNumber * recipes.PageSize < recipes.TotalItems
                }
            };
            return Ok(result);
        }

    }
}

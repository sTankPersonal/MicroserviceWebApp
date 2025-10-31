using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    public class IngredientController(IIngredientService ingredientService) : ControllerBase
    {
        private readonly IIngredientService _ingredientService = ingredientService;
        // GET api/Ingredient/AjaxList
        [HttpGet("Ajax/List")]
        public async Task<IActionResult> AjaxGetAll(FilterIngredient filterIngredient)
        {
            PagedResult<IngredientDto> ingredients = await _ingredientService.GetAllAsync(filterIngredient);
            AjaxReturnDto result = new ()
            {
                results = [..ingredients.Items.Select(i => new AjaxResultDto
                {
                    id = i.Id.ToString(),
                    text = i.Name
                })],
                pagination = new AjaxPaginationDto
                {
                    more = ingredients.PageNumber * ingredients.PageSize < ingredients.TotalItems
                }
            };
            return Ok(result);
        }

        //GET api/Ingredient/Ajax{id}
        [HttpGet("Ajax/{id}")]
        public async Task<IActionResult> GetIngredient(Guid id)
        {
            IngredientDto? ingredient = await _ingredientService.GetByIdAsync(id);
            if (ingredient == null)
                return NotFound();
            return Ok(new AjaxResultDto
            {
                id = ingredient.Id.ToString(),
                text = ingredient.Name
            });
        }
    }
}

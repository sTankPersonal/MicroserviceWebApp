using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.PresentationMVC.Controllers.Api
{
    [Route("api/[controller]")]
    public class IngredientController(IIngredientService ingredientService) : ControllerBase
    {
        private readonly IIngredientService _ingredientService = ingredientService;
        // GET api/Ingredient/AjaxList
        [HttpGet("AjaxList")]
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
    }
}

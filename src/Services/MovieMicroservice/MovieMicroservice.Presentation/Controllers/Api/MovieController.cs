using Microsoft.AspNetCore.Mvc;
using MovieMicroservice.Application.DTOs;
using MovieMicroservice.Application.Interfaces.Services;
using MovieMicroservice.Domain.Specifications;
using MovieMicroservice.Application.DTOs.Movie;
using BuildingBlocks.SharedKernel.Pagination;

namespace MovieMicroservice.Presentation.Controllers.Api
{
    [Route("api/[Controller]")]
    public class MovieController(IMovieService movieService) : ControllerBase
    {
        private readonly IMovieService _recipeService = movieService;
        // GET api/Recipe/AjaxList
        [HttpGet("Ajax/List")]
        public async Task<IActionResult> AjaxGetAll(FilterMovie filterMovie)
        {
            PagedResult<MovieDto> recipes = await _recipeService.GetAllAsync(filterMovie);
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

        //GET api/recipe/Ajax/{id}
        [HttpGet("Ajax/{id}")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            RecipeDto? recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(new AjaxResultDto
            {
                id = recipe.Id.ToString(),
                text = recipe.Name
            });
        }
    }
}

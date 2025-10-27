using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        //GET api/Category/AjaxList
        [HttpGet("AjaxList")]
        public async Task<IActionResult> AjaxGetAll([FromQuery] FilterCategory filterCategory)
        {
            PagedResult<CategoryDto> categories = await _categoryService.GetAllAsync(filterCategory);
            AjaxReturnDto result = new()
            {
                results = [..categories.Items.Select(c => new AjaxResultDto
                {
                    id = c.Id.ToString(),
                    text = c.Name
                })],
                pagination = new AjaxPaginationDto
                {
                    more = categories.PageNumber * categories.PageSize < categories.TotalItems
                }
            };
            return Ok(result);
        }
    }
}

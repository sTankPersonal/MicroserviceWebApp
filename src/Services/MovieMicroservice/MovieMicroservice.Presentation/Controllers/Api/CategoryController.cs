using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using MovieMicroservice.Application.DTOs;
using MovieMicroservice.Application.DTOs.Category;
using MovieMicroservice.Application.Interfaces.Services;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        //GET api/Category/AjaxList
        [HttpGet("Ajax/List")]
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

        //GET api/Category/Ajax/{id}
        [HttpGet("Ajax/{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            CategoryDto? category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(new AjaxResultDto{
                id = category.Id.ToString(),
                text = category.Name
            });
        }
    }
}

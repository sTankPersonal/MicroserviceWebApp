using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;


namespace RecipeMicroservice.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetRecipeById(Guid id)
        {
            CategoryDto? category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // GET: api/Category
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllCategories(string? searchName = null, int pageNumber = 1, int pageSize = 10)
        {
            PagedResult<CategoryDto> categories = await _categoryService.GetAllAsync(new FilterCategory(searchName, pageNumber, pageSize));
            return Ok(categories);
        }

        public async Task<IActionResult> GetCategoryCategories(FilterCategory filterCategory)
        {
            PagedResult<CategoryDto> recipes = await _categoryService.GetAllAsync(filterCategory);
            return Ok(recipes);
        }
    }
}

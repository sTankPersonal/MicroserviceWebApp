using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;
using RecipeMicroservice.Presentation.Models.Category;

namespace RecipeMicroservice.Presentation.Controllers.ViewModel
{
    /* GET: /Category - Get all categories and return List view
     * GET: /Category/{id} - Get category by id and return Details view
     * GET: /Category/Create - Return Create view
     * GET: /Category/Edit/{id} - Get category by id and return Edit view
     * GET: /Category/Delete/{id} - Get category by id and return Delete view
     * 
     * POST: /Category/Create - Create a new category and redirect to Details view
     * POST: /Category/Edit/{id} - Update a category and redirect to Details view
     * POST: /Category/Delete/{id} - Delete a category and redirect to List view
     */
    [Route("categories")]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;

        // GET: /Category
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllCategories(FilterCategory filterCategory)
        {
            PagedResult<CategoryDto> categories = await _categoryService.GetAllAsync(filterCategory);
            return View("List", ListCategoryViewModel.FromPagedResult(categories));
        }

        // GET: /Category/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            CategoryDto? category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View("Details", CategoryViewModel.FromDto(category));
        }

        // GET: /Category/Create
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateCategory()
        {
            return View("Create", new CreateCategoryViewModel());
        }

        // GET: /Category/Edit/{id}
        [HttpGet("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditCategory(Guid id)
        {
            CategoryDto? category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View("Edit", EditCategoryViewModel.FromDto(category));
        }

        // GET: /Category/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            CategoryDto? category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View("Delete", CategoryViewModel.FromDto(category));
        }

        // POST: /Category/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel model)
        {
            CreateCategoryDto dto = new ()
            {
                Name = model.Name
            };
            Guid newCategoryId = await _categoryService.CreateAsync(dto);
            return RedirectToAction("Details", new { id = newCategoryId });
        }

        // POST: /Category/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditCategory(Guid id, EditCategoryViewModel model)
        {
            UpdateCategoryDto dto = new ()
            {
                Name = model.Name
            };
            await _categoryService.UpdateAsync(id, dto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Category/Delete/{id}
        [HttpPost("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategoryConfirmed(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("List");
        }
    }
}

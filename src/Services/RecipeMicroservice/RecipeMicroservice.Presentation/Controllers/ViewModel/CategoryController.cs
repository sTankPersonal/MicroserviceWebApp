using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Category;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Presentation.Mappers;
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
        public async Task<IActionResult> GetAllCategories(FilterCategoryViewModel Filter)
        {
            PagedResult<CategoryDto> dtos = await _categoryService.GetAllAsync(Filter.ToFilter());
            Console.WriteLine("Dtos:");
            foreach (var i in dtos.items)
            {
                Console.WriteLine(i.Name);
            }
            Console.WriteLine("View Model:");
            foreach (var i in dtos.ToListViewModel().WithFilter(Filter).Items)
            {
                Console.WriteLine(i.Name);
            }
            return View("List", dtos.ToListViewModel().WithFilter(Filter));
        }

        // GET: /Category/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            CategoryDto? dto = await _categoryService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Details", dto.ToViewModel());
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
            CategoryDto? dto = await _categoryService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Edit", dto.ToViewModel());
        }

        // GET: /Category/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            CategoryDto? dto = await _categoryService.GetByIdAsync(id);
            return dto == null? NotFound() : View("Delete", dto.ToViewModel());
        }

        // POST: /Category/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel viewModel)
        {
            CreateCategoryDto dto = viewModel.ToCreateDto();
            Guid id = await _categoryService.CreateAsync(dto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Category/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditCategory(Guid id, UpdateCategoryViewModel viewModel)
        {
            UpdateCategoryDto dto = viewModel.ToUpdateDto();
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

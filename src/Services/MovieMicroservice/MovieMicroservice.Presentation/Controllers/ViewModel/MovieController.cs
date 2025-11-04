using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Application.DTOs.MovieCategory;
using MovieMicroservice.Application.Interfaces.Services;
using MovieMicroservice.Domain.Specifications;
using MovieMicroservice.Presentation.Models.Movie;
using MovieMicroservice.Presentation.Models.MovieCategory;

namespace MovieMicroservice.Presentation.Controllers.ViewModel
{
    /* RecipeController Returns a View model
     * GET: /Recipe/{id} - Get recipe by id and return Details view
     * GET: /Recipe - Get all recipes and return List view
     * GET: /Recipe/Create - Return Create view
     * GET: /Recipe/Edit/{id} - Get recipe by id and return Edit view
     * GET: /Recipe/Delete/{id} - Get recipe by id and return Delete view
     * 
     * POST: /Recipe/Create - Create a new recipe and redirect to Details view
     * POST: /Recipe/Edit/{id} - Update a recipe and redirect to Details view
     * POST: /Recipe/Delete/{id} - Delete a recipe and redirect to List view
     * 
     * POST: /Recipe/{id}/Instruction/Add/{instructionId} - Add an instruction to the recipe being created or edited
     * POST: /Recipe/{id}/Ingredient/Add/{ingredientId} - Add an ingredient to the recipe being created or edited
     * POST: /Recipe/{id}/Category/Add/{categoryId} - Add a category to the recipe being created or edited
     * 
     * POST: /Recipe/{id}/Instruction/Remove - Remove an instruction from the recipe being created or edited
     * POST: /Recipe/{id}/Ingredient/Remove - Remove an ingredient from the recipe being created or edited
     * POST: /Recipe/{id}/Category/Remove - Remove a category from the recipe being created or edited
     * 
     * POST: /Recipe/{id}/Instruction/Edit - Edit an instruction in the recipe being created or edited
     * POST: /Recipe/{id}/Ingredient/Edit - Edit an ingredient in the recipe being created or edited
     * POST: /Recipe/{id}/Category/Edit - Edit a category in the recipe being created or edited
     */
    [Route("[controller]")]
    public class MovieController(IMovieService movieService) : Controller
    {
        private readonly IMovieService _movieService = movieService;

        // GET: /Recipe/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            MovieDto? movie = await _movieService.GetByIdAsync(id);
			if (movie == null)
            {
                return NotFound();
            }
            return View("Details", MovieViewModel.FromDto(movie));
        }

        // GET: /Recipe
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllMovies(ListMovieViewModel listMovieViewModel)
        {
            FilterMovie filterMovie = new(listMovieViewModel.SearchName, listMovieViewModel.SearchCategoryId);
            PagedResult<MovieDto> movies = await _movieService.GetAllAsync(filterMovie);
            ListMovieViewModel newListMovieViewModel = ListMovieViewModel.FromPagedResult(movies, filterMovie.SearchName, filterMovie.SearchCategoryId);
            return View("List", newListMovieViewModel);
        }

        // GET: /Recipe/Create
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateMovie()
        {
            return View("Create", new CreateMovieViewModel());
        }

        // GET: /Recipe/Edit/{id}
        [HttpGet("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditMovie(Guid id)
        {
            MovieDto? movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            UpdateMovieViewModel viewModel = UpdateMovieViewModel.FromDto(movie);
            return View("Edit", viewModel);
        }

        // GET: /Recipe/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteMovie(Guid id)
        {
            MovieDto? movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View("Delete", MovieViewModel.FromDto(movie));
        }

        // POST: /Recipe/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateMovie(CreateMovieViewModel model)
        {
            CreateMovieDto createMovieDto = new()
            {
                Name = model.Name
            };
            Guid id = await _movieService.CreateAsync(createMovieDto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Recipe/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditMovie(Guid id, UpdateMovieViewModel model)
        {
            UpdateMovieDto dto = new()
            {
                Id = model.Id,
                Name = model.Name
            };
            await _movieService.UpdateAsync(id, dto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Recipe/Delete/{id}
        [HttpPost("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteMovieConfirmed(Guid id)
        {
            await _movieService.DeleteAsync(id);
            return RedirectToAction("List");
        }

        // POST: /Recipe/{id}/Category/Add
        [HttpPost("{id}/Category/Add")]
        [ActionName("AddCategory")]
        public async Task<IActionResult> AddCategory(Guid id, CreateMovieCategoryViewModel NewCategory)
        {
            await _movieService.CreateMovieCategoryAsync(id, NewCategory.CategoryId, new CreateMovieCategoryDto { });
            return RedirectToAction("Edit", new { id });
        }

        // POST: /Recipe/{id}/Category/Remove/{recipeCategoryId}
        [HttpPost("{id}/Category/Remove/{recipeCategoryId}")]
        [ActionName("RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(Guid id, Guid recipeCategoryId)
        {
            await _movieService.DeleteMovieCategoryAsync(id, recipeCategoryId);
            return RedirectToAction("Edit", new { id });
        }
    }
}

using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Pagination;
using MovieMicroservice.Application.DTOs.MovieCategory;
using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Domain.Specifications;

namespace MovieMicroservice.Application.Interfaces.Services
{
    public interface IMovieService : IBasicCrudService<Guid, MovieDto, CreateMovieDto, UpdateMovieDto>
    {
        public Task<PagedResult<MovieDto>> GetAllAsync(FilterMovie filter);

        //Aggregate Child - RecipeMovies
        public Task<Guid> CreateMovieCategoryAsync(Guid recipeId, Guid categoryId, CreateMovieCategoryDto dto);
        public Task UpdateMovieCategoryAsync(Guid recipeId, Guid recipeCategoryId, UpdateMovieCategoryDto dto);
        public Task DeleteMovieCategoryAsync(Guid recipeId,  Guid recipeCategoryId);
    }
}

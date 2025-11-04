using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Application.DTOs.MovieCategory;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Application.Mappers
{
    public static class MovieCategoryMapper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static MovieCategory ToEntity(this CreateMovieCategoryDto _dto) => new() {};
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static MovieCategory ToEntity(this CreateMovieCategoryDto dto, Guid movieId, Guid categoryId) => new()
        {
            MovieId = movieId,
            CategoryId = categoryId
        };

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public static MovieCategory ToEntity(this UpdateMovieCategoryDto _dto, MovieCategory movieCategory)
        {
            return movieCategory;
        }
        public static MovieCategoryDto ToDto(this MovieCategory recipeCategory) => new()
        {
            Id = recipeCategory.Id,
            MovieId = recipeCategory.MovieId,
            CategoryId = recipeCategory.CategoryId,
            CategoryName = recipeCategory.Category?.Name ?? string.Empty
        };
        public static IEnumerable<MovieCategoryDto> ToDtos(this IEnumerable<MovieCategory> recipeCategories) =>
            recipeCategories.Select(rc => rc.ToDto());
    }
}

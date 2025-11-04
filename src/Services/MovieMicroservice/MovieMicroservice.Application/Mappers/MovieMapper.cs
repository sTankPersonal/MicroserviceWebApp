using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Domain.Aggregates;

namespace MovieMicroservice.Application.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToEntity(this CreateMovieDto dto) => new()
        {
            Name = dto.Name
        };

        public static Movie ToEntity(this UpdateMovieDto dto, Movie movie)
        {
            movie.Name = dto.Name;
            movie.HasWatched = dto.HasWatched;
            return movie;
        }

        public static MovieDto ToDto(this Movie movie) => new()
        {
            Id = movie.Id,
            Name = movie.Name,
            HasWatched = movie.HasWatched,
            Categories = [.. movie.MovieCategories.Select(rc => rc.ToDto())],
            Photos = [.. movie.Photos.Select(p => p.ToDto())]
        };
        public static IEnumerable<MovieDto> ToDtos(this IEnumerable<Movie> recipes)
        {
            return recipes.Select(r => r.ToDto());
        }
    }
}

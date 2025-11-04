using MovieMicroservice.Application.DTOs.MovieCategory;

namespace MovieMicroservice.Application.DTOs.Movie
{
    public class UpdateMovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasWatched { get; set; } = false;
        public IEnumerable<MovieCategoryDto> Categories { get; set; } = [];
    }
}

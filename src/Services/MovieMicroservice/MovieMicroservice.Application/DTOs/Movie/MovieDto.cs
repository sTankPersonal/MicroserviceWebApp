using MovieMicroservice.Application.DTOs.MovieCategory;
using MovieMicroservice.Application.DTOs.Photo;

namespace MovieMicroservice.Application.DTOs.Movie
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasWatched { get; set; } = false;
        public IEnumerable<MovieCategoryDto> Categories { get; set; } = [];
        public IEnumerable<PhotoDto> Photos { get; set; } = [];
    }
}

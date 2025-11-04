using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Presentation.Models.MovieCategory;

namespace MovieMicroservice.Presentation.Models.Movie
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasWatched { get; set; } = false;
        public IEnumerable<MovieCategoryViewModel> Categories { get; set; } = [];

        public static MovieViewModel FromDto(MovieDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            HasWatched = dto.HasWatched,
            Categories = dto.Categories.Select(MovieCategoryViewModel.FromDto)
        };
        public bool HasCategories()
        {
            return Categories.Any();
        }
    }
}

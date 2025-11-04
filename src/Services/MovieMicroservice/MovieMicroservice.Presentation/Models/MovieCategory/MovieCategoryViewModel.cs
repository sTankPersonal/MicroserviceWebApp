using MovieMicroservice.Application.DTOs.MovieCategory;

namespace MovieMicroservice.Presentation.Models.MovieCategory
{
    public class MovieCategoryViewModel
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid CategoryId { get; set; }

        // Display Properties
        public string CategoryName { get; set; } = string.Empty;

        public static MovieCategoryViewModel FromDto(MovieCategoryDto dto)
        {
            return new MovieCategoryViewModel
            {
                Id = dto.Id,
                MovieId = dto.MovieId,
                CategoryId = dto.CategoryId,
                CategoryName = dto.CategoryName
            };
        }
    }
}

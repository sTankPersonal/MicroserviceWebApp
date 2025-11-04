using MovieMicroservice.Application.DTOs.MovieCategory;
using System.ComponentModel.DataAnnotations;

namespace MovieMicroservice.Presentation.Models.MovieCategory
{
    public class EditMovieCategoryViewModel
    {
        public Guid MovieId { get; set; }
        public Guid CategoryId { get; set; }

        public static EditMovieCategoryViewModel FromDto(MovieCategoryDto dto)
        {
            return new EditMovieCategoryViewModel
            {
                MovieId = dto.MovieId,
                CategoryId = dto.CategoryId
            };
        }
    }
}

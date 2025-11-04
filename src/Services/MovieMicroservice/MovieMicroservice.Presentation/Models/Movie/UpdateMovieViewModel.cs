using MovieMicroservice.Application.DTOs.Movie;
using MovieMicroservice.Presentation.Models.MovieCategory;
using System.ComponentModel.DataAnnotations;

namespace MovieMicroservice.Presentation.Models.Movie
{
    public class UpdateMovieViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter a name for the recipe.")]
        [Display(Name = "Recipe Name")]
        [StringLength(200, ErrorMessage = "Recipe name cannot be longer than 200 characters.")]
        public string Name { get; set; } = string.Empty;
        public ICollection<MovieCategoryViewModel> Categories { get; set; } = [];
        

        public static UpdateMovieViewModel FromDto(MovieDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Categories = [.. dto.Categories.Select(MovieCategoryViewModel.FromDto)]
        };
        public bool HasCategories() => Categories != null && Categories.Count > 0;
    }
}

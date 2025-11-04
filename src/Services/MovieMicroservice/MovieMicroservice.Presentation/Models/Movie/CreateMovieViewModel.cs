using System.ComponentModel.DataAnnotations;

namespace MovieMicroservice.Presentation.Models.Movie
{
    public class CreateMovieViewModel
    {
        [Required(ErrorMessage = "Please enter a name for the recipe.")]
        [Display(Name = "Recipe Name", Prompt = "Please a name for the new recipe...")]
        public string Name { get; set; } = string.Empty;
    }
}

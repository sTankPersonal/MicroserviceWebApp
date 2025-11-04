using System.ComponentModel.DataAnnotations;

namespace MovieMicroservice.Presentation.Models.MovieCategory
{
    public class CreateMovieCategoryViewModel
    {
        [Required]
        public Guid CategoryId { get; set; }
    }
}

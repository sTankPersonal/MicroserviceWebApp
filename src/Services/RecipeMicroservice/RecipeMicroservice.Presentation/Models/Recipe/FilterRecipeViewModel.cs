using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class FilterRecipeViewModel
    {
        [Display(Name = "Search Recipe Name")]
        public string? SearchName { get; set; } = null;
        [Display(Name = "Search Categories")]
        public Guid? SearchCategoryId { get; set; } = null;
        [Display(Name = "Search Ingredients")]
        public Guid? SearchIngredientId { get; set; } = null;
    }
}

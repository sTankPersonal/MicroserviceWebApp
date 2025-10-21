using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class CreateRecipeViewModel
    {
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Prep Time (Minutes)")]
        public int PrepTimeInMinutes { get; set; } = 0;
        [Display(Name = "Cook Time (Minutes)")]
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
    }
}

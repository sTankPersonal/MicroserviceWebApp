using RecipeMicroservice.Application.DTOs.Instruction;
using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Application.DTOs.Recipe
{
    public class CreateRecipeDto
    {
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Prep Time (Minutes)")]
        public int PrepTimeInMinutes { get; set; } = 0;
        [Display(Name = "Cook Time (Minutes)")]
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
    }
}

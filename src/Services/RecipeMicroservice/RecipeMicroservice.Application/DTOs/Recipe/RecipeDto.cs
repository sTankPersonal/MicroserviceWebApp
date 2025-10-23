using RecipeMicroservice.Application.DTOs.RecipeCategory;
using RecipeMicroservice.Application.DTOs.RecipeIngredient;
using RecipeMicroservice.Application.DTOs.RecipeInstruction;

namespace RecipeMicroservice.Application.DTOs.Recipe
{
    public class RecipeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public IEnumerable<RecipeInstructionDto> Instructions { get; set; } = [];
        public IEnumerable<RecipeIngredientDto> Ingredients { get; set; } = [];
        public IEnumerable<RecipeCategoryDto> Categories { get; set; } = [];
    }
}

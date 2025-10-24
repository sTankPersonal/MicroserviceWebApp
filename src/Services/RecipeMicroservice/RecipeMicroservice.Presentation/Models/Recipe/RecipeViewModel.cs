using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public List<RecipeCategoryViewModel> Categories { get; set; } = [];
        public List<RecipeIngredientViewModel> Ingredients { get; set; } = [];
        public List<RecipeInstructionViewModel> Instructions { get; set; } = [];

        public static RecipeViewModel FromDto(RecipeDto dto)
        {
            return new RecipeViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                PrepTimeInMinutes = dto.PrepTimeInMinutes,
                CookTimeInMinutes = dto.CookTimeInMinutes,
                Servings = dto.Servings,
                Categories = [.. dto.Categories.Select(RecipeCategoryViewModel.FromDto)],
                Ingredients = [.. dto.Ingredients.Select(RecipeIngredientViewModel.FromDto)],
                Instructions = [.. dto.Instructions.Select(RecipeInstructionViewModel.FromDto)]
            };
        }

        public bool HasCategories()
        {
            return Categories.Count > 0;
        }
        public bool HasIngredient()
        {
            return Ingredients.Count > 0;
        }
        public bool HasInstructions()
        {
            return Instructions.Count > 0;
        }
    }
}

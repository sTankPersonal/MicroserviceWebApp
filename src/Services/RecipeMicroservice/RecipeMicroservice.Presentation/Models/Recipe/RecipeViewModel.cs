using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Presentation.Models.RecipeCategory;
using RecipeMicroservice.Presentation.Models.RecipeIngredient;
using RecipeMicroservice.Presentation.Models.RecipeInstruction;

namespace RecipeMicroservice.Presentation.Models.Recipe
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public IEnumerable<RecipeInstructionViewModel> Instructions { get; set; } = [];
        public IEnumerable<RecipeIngredientViewModel> Ingredients { get; set; } = [];
        public IEnumerable<RecipeCategoryViewModel> Categories { get; set; } = [];

        public static RecipeViewModel FromDto(RecipeDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            PrepTimeInMinutes = dto.PrepTimeInMinutes,
            CookTimeInMinutes = dto.CookTimeInMinutes,
            Servings = dto.Servings,
            Instructions = dto.Instructions.Select(RecipeInstructionViewModel.FromDto),
            Ingredients = dto.Ingredients.Select(RecipeIngredientViewModel.FromDto),
            Categories = dto.Categories.Select(RecipeCategoryViewModel.FromDto)
        };

        public bool HasInstructions()
        {
            return Instructions.Any();
        }
        public bool HasIngredients()
        {
            return Ingredients.Any();
        }
        public bool HasCategories()
        {
            return Categories.Any();
        }
    }
}

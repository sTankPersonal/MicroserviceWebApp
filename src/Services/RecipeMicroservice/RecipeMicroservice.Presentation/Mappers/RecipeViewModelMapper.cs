using RecipeMicroservice.Application.DTOs.Recipe;
using RecipeMicroservice.Presentation.Models.Recipe;

namespace RecipeMicroservice.Presentation.Mappers
{
    public static class RecipeViewModelMapper
    {
        public static RecipeViewModel ToViewModel(this RecipeDto dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            PrepTimeInMinutes = dto.PrepTimeInMinutes,
            CookTimeInMinutes = dto.CookTimeInMinutes,
            Servings = dto.Servings,
            Ingredients = dto.Ingredients.ToViewModel(),
            Instructions = dto.Instructions
        };
    }
}

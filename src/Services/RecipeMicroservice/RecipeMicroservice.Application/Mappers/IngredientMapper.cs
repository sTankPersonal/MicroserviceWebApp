using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class IngredientMapper
    {
        public static Ingredient ToEntity(this CreateIngredientDto dto)
        {
            return new Ingredient
            {
                Name = dto.Name
            };
        }
        public static IngredientDto ToDto(this Ingredient ingredient)
        {
            return new IngredientDto
            {
                Id = ingredient.Id,
                Name = ingredient.Name
            };
        }
        public static IEnumerable<IngredientDto> ToDtos(this IEnumerable<Ingredient> ingredients)
        {
            return ingredients.Select(i => i.ToDto());
        }
    }
}

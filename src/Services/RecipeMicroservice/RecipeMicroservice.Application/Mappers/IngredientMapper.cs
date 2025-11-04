using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class IngredientMapper
    {
        public static Ingredient ToEntity(this CreateIngredientDto dto) => new()
        {
            Name = dto.Name
        };
        public static Ingredient ToEntity(this UpdateIngredientDto dto, Ingredient ingredient)
        {
            ingredient.Name = dto.Name;
            return ingredient;
        }

        public static IngredientDto ToDto(this Ingredient ingredient) => new()
        {
            Id = ingredient.Id,
            Name = ingredient.Name
        };
        public static IEnumerable<IngredientDto> ToDtos(this IEnumerable<Ingredient> ingredients) => 
            ingredients.Select(i => i.ToDto());
    }
}
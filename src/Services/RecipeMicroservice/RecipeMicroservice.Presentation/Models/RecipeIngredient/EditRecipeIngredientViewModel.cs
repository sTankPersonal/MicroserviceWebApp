using System.ComponentModel.DataAnnotations;

namespace RecipeMicroservice.Presentation.Models.RecipeIngredient
{
    public class EditRecipeIngredientViewModel
    {
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public Guid UnitId { get; set; }
        [Range(0.0001, double.MaxValue, ErrorMessage = "Please enter a positive number for quantity.")]
        public decimal Quantity { get; set; }

        public static EditRecipeIngredientViewModel FromDto(Application.DTOs.RecipeIngredient.RecipeIngredientDto dto)
        {
            return new EditRecipeIngredientViewModel
            {
                RecipeId = dto.RecipeId,
                IngredientId = dto.IngredientId,
                UnitId = dto.UnitId,
                Quantity = dto.Quantity
            };
        }
    }
}

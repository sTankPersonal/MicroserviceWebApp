using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Photo;
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
        public PagedResult<RecipeInstructionDto> Instructions { get; set; } = new();
        public PagedResult<RecipeIngredientDto> Ingredients { get; set; } = new();
        public PagedResult<RecipeCategoryDto> Categories { get; set; } = new();
        public PagedResult<PhotoDto> Photos { get; set; } = new();
    }
}

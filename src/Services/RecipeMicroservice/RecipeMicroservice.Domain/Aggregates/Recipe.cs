using BuildingBlocks.SharedKernel.Entities;
using RecipeService.Domain.Entities;

namespace RecipeService.Domain.Aggregates
{
    public class Recipe : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public int PrepTimeInMinutes { get; set; } = 0;
        public int CookTimeInMinutes { get; set; } = 0;
        public int Servings { get; set; } = 0;
        public ICollection<RecipeCategory> RecipeCategories { get; set; } = [];
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
        public ICollection<Instruction> Instructions { get; set; } = [];
    }
}

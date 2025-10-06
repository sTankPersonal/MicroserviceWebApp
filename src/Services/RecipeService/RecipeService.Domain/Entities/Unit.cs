using BuildingBlocks.SharedKernel.Entities;

namespace RecipeService.Domain.Entities
{
    public class Unit : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}

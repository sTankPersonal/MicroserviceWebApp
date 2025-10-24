using BuildingBlocks.SharedKernel.Entities;

namespace RecipeMicroservice.Domain.Entities
{
    public class Unit : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
    }
}

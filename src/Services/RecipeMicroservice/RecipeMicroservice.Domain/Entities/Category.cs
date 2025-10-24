using BuildingBlocks.SharedKernel.Entities;

namespace RecipeMicroservice.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public ICollection<RecipeCategory> RecipeCategories { get; set; } = [];
    }
}

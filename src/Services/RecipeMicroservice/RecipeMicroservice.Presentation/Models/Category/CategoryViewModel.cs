using RecipeMicroservice.Presentation.Interfaces.Models;

namespace RecipeMicroservice.Presentation.Models.Category
{
    public class CategoryViewModel : IHasEntity<CategoryViewModel, Guid>
    {
        public string Name { get; set; } = string.Empty;

        // IHasEntity
        public required Guid Id { get; set; }
        public CategoryViewModel WithId(Guid id) => (Id = id, this).Item2;
    }
}

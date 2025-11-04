using BuildingBlocks.SharedKernel.Entities;

namespace MovieMicroservice.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public ICollection<MovieCategory> MovieCategories { get; set; } = [];
    }
}

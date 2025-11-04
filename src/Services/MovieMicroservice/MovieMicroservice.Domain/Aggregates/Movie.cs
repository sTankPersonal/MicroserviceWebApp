using BuildingBlocks.SharedKernel.Entities;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Domain.Aggregates
{
    public class Movie : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public bool HasWatched { get; set; } = false;
        public ICollection<MovieCategory> MovieCategories { get; set; } = [];
        public ICollection<Photo> Photos { get; set; } = [];
    }
}

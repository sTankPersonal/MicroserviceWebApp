using BuildingBlocks.SharedKernel.Entities;
using MovieMicroservice.Domain.Aggregates;

namespace MovieMicroservice.Domain.Entities
{
    public class MovieCategory : BaseEntity<Guid>
    {
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

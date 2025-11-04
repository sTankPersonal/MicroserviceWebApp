using BuildingBlocks.SharedKernel.Entities;
using MovieMicroservice.Domain.Aggregates;

namespace MovieMicroservice.Domain.Entities
{
    public class Photo : BaseEntity<Guid>
    {
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}

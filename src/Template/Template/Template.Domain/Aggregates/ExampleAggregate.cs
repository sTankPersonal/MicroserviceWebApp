using BuildingBlocks.SharedKernel.Entities;
using Template.Domain.Entities;

namespace Template.Domain.Aggregates
{
    public class ExampleAggregate : BaseEntity<Guid>
    {
        public ICollection<ExampleEntity> ExampleEntities { get; private set; } = [];
        public ExampleAggregate() { } // Needed for ORM

        public ExampleAggregate(Guid id, ICollection<ExampleEntity> entities) : base(id)
        {
            ExampleEntities = entities;
        }

        public void AddExampleEntity(ExampleEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            ExampleEntities.Add(entity);
        }
    }
}

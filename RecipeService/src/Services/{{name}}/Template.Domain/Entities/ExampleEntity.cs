using BuildingBlocks.SharedKernel.Entities;

namespace Template.Domain.Entities
{
    public class ExampleEntity : BaseEntity<Guid>
    {
        public string Attribute { get; private set; } = string.Empty;

        private ExampleEntity() { }
        public ExampleEntity(Guid id, string attribute) : base(id)
        {
            Attribute = attribute ?? throw new ArgumentNullException(nameof(attribute), "Attribute cannot be null");
        }

        public void UpdateAttribute(string newAttribute)
        {
            Attribute = newAttribute ?? throw new ArgumentNullException(nameof(newAttribute), "New name cannot be null");
        }
    }
}

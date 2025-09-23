

using BuildingBlocks.SharedKernel.ValueObjects;

namespace Template.Domain.ValueObjects
{
    public sealed class ExampleValueObject : BaseValueObject
    {
        public int Attribute { get; }
        public string StringAttribute { get; } = string.Empty;

        private ExampleValueObject() { }
        public ExampleValueObject(int attribute, string stringAttribute)
        {
            Attribute = attribute;
            StringAttribute = stringAttribute ?? throw new ArgumentNullException(nameof(stringAttribute));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Attribute;
            yield return StringAttribute;
        }
    }
}

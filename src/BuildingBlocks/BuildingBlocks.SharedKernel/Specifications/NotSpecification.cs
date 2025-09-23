
namespace BuildingBlocks.SharedKernel.Specifications
{
    internal class NotSpecification<T>(Specification<T> spec) : Specification<T>
    {
        private readonly Specification<T> _spec = spec;
        public override bool IsSatisfiedBy(T entity)
        {
            return !_spec.IsSatisfiedBy(entity);
        }
    }
}

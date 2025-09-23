
namespace BuildingBlocks.SharedKernel.Specifications
{
    internal class AndSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
    {
        private readonly Specification<T> _left = left;
        private readonly Specification<T> _right = right;

        public override bool IsSatisfiedBy(T entity)
        {
            return _left.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity);
        }
    }
}

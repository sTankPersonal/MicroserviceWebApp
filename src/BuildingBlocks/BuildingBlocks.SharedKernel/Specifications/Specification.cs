
namespace BuildingBlocks.SharedKernel.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T entity);

        public Specification<T> And(Specification<T> other) => new AndSpecification<T>(this, other);
        public Specification<T> Or(Specification<T> other) => new OrSpecification<T>(this, other);
        public Specification<T> Not() => new NotSpecification<T>(this);
    }
}


namespace BuildingBlocks.SharedKernel.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}

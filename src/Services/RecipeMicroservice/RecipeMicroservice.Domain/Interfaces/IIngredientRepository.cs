using BuildingBlocks.SharedKernel.InfrastructureServices;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient, Guid, FilterIngredient>{ }
}

using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
    }
}

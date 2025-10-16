using BuildingBlocks.SharedKernel.Repositories;
using RecipeMicroservice.Domain.Aggregates;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
    }
}

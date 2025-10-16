using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Domain.Aggregates;

namespace RecipeService.Domain.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
    }
}

using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Domain.Entities;

namespace RecipeService.Domain.Interfaces
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
    }
}

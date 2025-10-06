using BuildingBlocks.SharedKernel.DomainServices;
using RecipeService.Application.DTOs.Recipe;

namespace RecipeService.Application.Interfaces.Services
{
    public interface IRecipeService : IBasicCrudService<Guid, RecipeDto, CreateRecipeDto, UpdateRecipeDto>
    {
    }
}

using BuildingBlocks.SharedKernel.DomainServices;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IIngredientService : IBasicCrudService<Guid, IngredientDto, CreateIngredientDto, UpdateIngredientDto, FilterIngredient>
    {
    }
}

using BuildingBlocks.SharedKernel.DomainServices;
using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Ingredient;
using RecipeService.Application.Queries.Category;

namespace RecipeService.Application.Interfaces.Services
{
    public interface IIngredientService : IBasicCrudService<Guid, InstructionDto, CreateIngredientDto, UpdateIngredientDto>
    {
        public Task<PagedResult<InstructionDto>> GetAllAsync(GetIngredientQuery query);
    }
}

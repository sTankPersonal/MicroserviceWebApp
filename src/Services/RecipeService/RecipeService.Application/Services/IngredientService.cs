using BuildingBlocks.SharedKernel.Repositories;
using RecipeService.Application.DTOs.Ingredient;
using RecipeService.Application.Interfaces.Services;

namespace RecipeService.Application.Services
{
    public class IngredientService : IIngredientService
    {
        public Task<InstructionDto> CreateAsync(CreateIngredientDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<InstructionDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InstructionDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid id, UpdateIngredientDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

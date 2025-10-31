using BuildingBlocks.SharedKernel.Pagination;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Mappers;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
{
    public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository = ingredientRepository;
        public async Task<Guid> CreateAsync(CreateIngredientDto dto)
        {
            Ingredient ingredient = dto.ToEntity();
            await _ingredientRepository.AddAsync(ingredient);
            return ingredient.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            Ingredient? ingredient = await _ingredientRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Ingredient with id {id} not found.");
            await _ingredientRepository.DeleteAsync(ingredient);
        }

        public async Task<PagedResult<IngredientDto>> GetAllAsync(FilterIngredient filter)
        {
            PagedResult<Ingredient> pagedIngredients =  await _ingredientRepository.GetAllAsync(filter);
            return pagedIngredients.Map(i => i.ToDto());
        }

        public async Task<PagedResult<IngredientDto>> GetAllAsync(PagedQuery query)
        {
            PagedResult<Ingredient> pagedIngredients =  await _ingredientRepository.GetAllAsync(query);
            return pagedIngredients.Map(i => i.ToDto());
        }

        public async Task<IngredientDto?> GetByIdAsync(Guid id)
        {
            return (await _ingredientRepository.GetByIdAsync(id) ?? null)?.ToDto();
        }

        public async Task UpdateAsync(Guid id, UpdateIngredientDto dto)
        {
            Ingredient? ingredient = await _ingredientRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Ingredient with id {id} not found.");
            ingredient.Name = dto.Name;
            await _ingredientRepository.UpdateAsync(ingredient);
        }
    }
}

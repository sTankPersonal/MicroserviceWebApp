using BuildingBlocks.SharedKernel.DomainServices;
using RecipeMicroservice.Application.DTOs.Ingredient;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Application.Mappers;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Domain.Interfaces;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Application.Services
{
    public class IngredientService(IIngredientRepository ingredientRepository) : BasicCrudService<Ingredient, Guid, IngredientDto, CreateIngredientDto, UpdateIngredientDto, FilterIngredient>(ingredientRepository),IIngredientService
    {
        protected override Ingredient ToEntity(CreateIngredientDto dto) => dto.ToEntity();
        protected override void ToEntity(UpdateIngredientDto dto, Ingredient entity) => _ = dto.ToEntity(entity);
        protected override IngredientDto ToDto(Ingredient entity) => entity.ToDto();
    }
}

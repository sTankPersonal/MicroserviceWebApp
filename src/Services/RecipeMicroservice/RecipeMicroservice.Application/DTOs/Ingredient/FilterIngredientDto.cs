using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Application.DTOs.Ingredient
{
    public class FilterIngredientDto(string? searchName, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
    }
}

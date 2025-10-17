using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterIngredient(string? searchName, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
    }
}

using BuildingBlocks.SharedKernel.Pagination;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterIngredient : PagedQuery
    {
        public string SearchName { get; init; } = string.Empty;
    }
}

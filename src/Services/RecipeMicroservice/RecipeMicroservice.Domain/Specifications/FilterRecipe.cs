using BuildingBlocks.SharedKernel.Pagination;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterRecipe : PagedQuery
    {
        public string? SearchName { get; init; } = string.Empty;
        public Guid? SearchCategoryId { get; init; }
        public Guid? SearchIngredientId { get; init; }
    }
}

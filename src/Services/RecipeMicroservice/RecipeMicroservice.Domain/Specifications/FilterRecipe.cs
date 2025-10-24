using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterRecipe(string? SearchName = null, string? SearchCategories = null, string? SearchIngredients = null, int PageNumber = 1, int PageSize = 10) : PagedQuery(PageNumber, PageSize)
    {
        public string? SearchName { get; } = SearchName;
        public string? SearchCategories { get; } = SearchCategories;
        public string? SearchIngredients { get; } = SearchIngredients;
    }
}

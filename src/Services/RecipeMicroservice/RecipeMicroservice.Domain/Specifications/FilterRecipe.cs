using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterRecipe(string? searchName, string? searchCategories, string? searchIngredients, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
        public string? SearchCategories { get; } = searchCategories;
        public string? SearchIngredients { get; } = searchIngredients;
    }
}

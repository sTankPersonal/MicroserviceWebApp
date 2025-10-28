using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterRecipe(string? SearchName = null, Guid? SearchCategoryId = null, Guid? SearchIngredientId = null, int PageNumber = 1, int PageSize = 10) : PagedQuery(PageNumber, PageSize)
    {
        public string? SearchName { get; } = SearchName;
        public Guid? SearchCategoryId { get; } = SearchCategoryId;
        public Guid? SearchIngredientId { get; } = SearchIngredientId;
    }
}

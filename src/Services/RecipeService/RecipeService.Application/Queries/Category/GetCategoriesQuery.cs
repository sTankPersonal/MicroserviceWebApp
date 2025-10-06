using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeService.Application.Queries.Category
{
    public class GetIngredientQuery(string? searchName, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
    }
}

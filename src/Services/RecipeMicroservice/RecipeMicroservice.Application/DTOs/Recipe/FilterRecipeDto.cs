using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeService.Application.DTOs.Recipe
{
    public class FilterRecipeDto(string? searchName, int? searchPrepTimeInMinutes, int? searchCookTimeInMinutes, int? searchServings, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
        public int? SearchPrepTimeInMinutes { get; } = searchPrepTimeInMinutes;
        public int? SearchCookTimeInMinutes { get; } = searchCookTimeInMinutes;
        public int? SearchServings { get; } = searchServings;
    }
}

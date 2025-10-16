using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeService.Application.DTOs.Unit
{
    public class FilterUnitDto(string? searchName, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
    }
}

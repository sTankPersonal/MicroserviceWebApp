using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Application.DTOs.Category
{
    public class FilterCategoryDto(string? searchName, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchName { get; } = searchName;
    }
}

using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeService.Application.Queries.Instruction
{
    public class GetInstructionQuery(string? searchDescription, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchDescription{ get; } = searchDescription;
    }
}

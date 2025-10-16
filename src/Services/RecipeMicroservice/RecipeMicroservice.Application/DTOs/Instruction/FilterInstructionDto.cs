using BuildingBlocks.SharedKernel.Repositories;

namespace RecipeMicroservice.Application.DTOs.Instruction
{
    public class FilterInstructionDto(string? searchDescription, int pageNumber = 1, int pageSize = 10) : PagedQuery(pageNumber, pageSize)
    {
        public string? SearchDescription{ get; } = searchDescription;
    }
}

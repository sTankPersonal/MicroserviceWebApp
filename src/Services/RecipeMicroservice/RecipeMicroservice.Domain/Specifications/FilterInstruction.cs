using BuildingBlocks.SharedKernel.Pagination;

namespace RecipeMicroservice.Domain.Specifications
{
    public record FilterInstruction : PagedQuery
    {
        public string? SearchDescription{ get; init } = string.Empty;
    }
}

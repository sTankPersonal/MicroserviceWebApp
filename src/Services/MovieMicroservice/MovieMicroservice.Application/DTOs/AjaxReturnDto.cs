namespace MovieMicroservice.Application.DTOs
{
    public class AjaxReturnDto
    {
        public IReadOnlyList<AjaxResultDto> results { get; set; } = [];
        public AjaxPaginationDto pagination { get; set; } = new();
    }
}

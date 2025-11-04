namespace MovieMicroservice.Application.DTOs.Photo
{
    public class DeletePhotoDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
    }
}

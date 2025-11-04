namespace MovieMicroservice.Application.DTOs.Photo
{
    public class UploadPhotoDto
    {
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] Content { get; set; } = [];
    }
}

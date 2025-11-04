using MovieMicroservice.Application.DTOs.Photo;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Application.Mappers
{
    public static class PhotoMapper
    {
        public static PhotoDto ToDto(this Photo photo) => new()
        {
            Id = photo.Id,
            Url = photo.Url
        };
        public static IEnumerable<PhotoDto> ToDtos(this IEnumerable<Photo> photos) => 
            photos.Select(p => p.ToDto());
    }
}

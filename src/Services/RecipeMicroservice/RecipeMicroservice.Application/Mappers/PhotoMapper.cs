using RecipeMicroservice.Application.DTOs.Photo;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Application.Mappers
{
    public static class PhotoMapper
    {
        public static PhotoDto ToDto(this Photo photo)
        {
            return new PhotoDto
            {
                Id = photo.Id,
                Url = photo.Url
            };
        }
        public static IEnumerable<PhotoDto> ToDtos(this IEnumerable<Photo> photos)
        {
            return photos.Select(p => p.ToDto());
        }
    }
}

using MovieMicroservice.Application.DTOs.Photo;

namespace MovieMicroservice.Application.Interfaces.Services
{
    public interface IFileStorageService
    {
        Task<PhotoDto> UploadFileAsync(UploadPhotoDto uploadFileDto);
        Task DeleteFileAsync(Guid id);
    }
}

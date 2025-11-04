using RecipeMicroservice.Application.DTOs.Photo;

namespace RecipeMicroservice.Application.Interfaces.Services
{
    public interface IFileStorageService
    {
        Task<PhotoDto> UploadFileAsync(UploadPhotoDto uploadFileDto);
        Task DeleteFileAsycn(Guid id);
    }
}

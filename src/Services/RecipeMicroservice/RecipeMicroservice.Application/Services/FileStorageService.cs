using RecipeMicroservice.Application.DTOs.Photo;
using RecipeMicroservice.Application.Interfaces.Services;

namespace RecipeMicroservice.Application.Services
{
    public class FileStorageService : IFileStorageService
    {
        public Task DeleteFile(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PhotoDto> UploadFileAsync(UploadPhotoDto uploadFileDto)
        {
            throw new NotImplementedException();
        }
    }
}

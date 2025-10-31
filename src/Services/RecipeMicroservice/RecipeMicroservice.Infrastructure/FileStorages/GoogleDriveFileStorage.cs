using BuildingBlocks.SharedKernel.Streams;
using RecipeMicroservice.Domain.Entities;
using RecipeMicroservice.Infrastructure.Interfaces;

namespace RecipeMicroservice.Infrastructure.FileStorages
{
    public class GoogleDriveFileStorage : IPhotoFileStorage
    {
        public Task DeleteFileAsync(Photo entity)
        {
            throw new NotImplementedException();
        }

        public Task<Photo> UploadFileAsync(FileStreams fileStreams)
        {
            throw new NotImplementedException();
        }
    }
}

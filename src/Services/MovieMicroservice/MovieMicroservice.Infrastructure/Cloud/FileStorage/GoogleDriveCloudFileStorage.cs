using BuildingBlocks.SharedKernel.Streams;
using Google.Apis.Drive.v3;
using Google.Apis.Upload;
using MovieMicroservice.Domain.Entities;
using MovieMicroservice.Domain.Interfaces;

namespace MovieMicroservice.Infrastructure.Cloud.FileStorage
{
    public class GoogleDriveCloudFileStorage(DriveService driveService) : IPhotoFileStorage
    {
        private readonly DriveService _driveService = driveService;
        public Task DeleteFileAsync(Photo entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Photo> UploadFileAsync(FileStreams fileStreams)
        {
            Google.Apis.Drive.v3.Data.File file = new()
            {
                Name = fileStreams.FileName,
                MimeType = fileStreams.ContentType,
                Parents = ["1BHq8KV7N-mt7epmBcLZtS883yFxi51dk"]
            };

            FilesResource.CreateMediaUpload request = _driveService.Files.Create(file, fileStreams.OpenStream, fileStreams.ContentType);
            request.Fields = "id, webContentLink, webViewLink";

            IUploadProgress result = await request.UploadAsync();

            if (result.Status != UploadStatus.Completed)
            {
                throw new System.Exception($"File upload failed: {result.Exception}");
            }
            return new Photo
            {
                Url = request.ResponseBody.WebContentLink
            };
        }
    }
}

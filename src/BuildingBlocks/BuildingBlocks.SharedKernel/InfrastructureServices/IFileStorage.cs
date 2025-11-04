using BuildingBlocks.SharedKernel.Streams;

namespace BuildingBlocks.SharedKernel.InfrastructureServices
{
    public interface IFileStorage<T> : IInfrastructureService
    {
        Task<T> UploadFileAsync(FileStreams fileStreams);
        Task DeleteFileAsync(T entity);
    }
}

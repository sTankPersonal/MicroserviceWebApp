namespace BuildingBlocks.SharedKernel.DomainServices
{
    public interface IFileStorageService<TId, TDto, TCreateDto> : IDomainService
    {
        Task<TDto> UploadFileAsync(TCreateDto createDto);
        Task DeleteFile(TId id);
    }
}

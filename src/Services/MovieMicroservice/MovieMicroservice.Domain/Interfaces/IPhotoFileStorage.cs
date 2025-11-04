using BuildingBlocks.SharedKernel.InfrastructureServices;
using MovieMicroservice.Domain.Entities;

namespace MovieMicroservice.Domain.Interfaces
{
    public interface IPhotoFileStorage : IFileStorage<Photo>
    {
    }
}

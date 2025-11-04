using BuildingBlocks.SharedKernel.InfrastructureServices;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Domain.Interfaces
{
    public interface IPhotoFileStorage : IFileStorage<Photo>
    {
    }
}

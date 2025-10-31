using BuildingBlocks.SharedKernel.InfrastructureServices;
using RecipeMicroservice.Domain.Entities;

namespace RecipeMicroservice.Infrastructure.Interfaces
{
    public interface IPhotoFileStorage : IFileStorage<Photo>
    {
    }
}

using Template.Application.DTOs;

namespace Template.Application.Interfaces.Services
{
    internal interface IExampleService : IApplicationService
    {
        Task<ExampleDto> GetById(Guid id);
    }
}

using Template.Application.DTOs;

namespace Template.Application.Interfaces.Services
{
    internal interface IExampleService
    {
        Task<ExampleDto> GetById(Guid id);
    }
}

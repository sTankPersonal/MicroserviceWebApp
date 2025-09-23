using Template.Application.DTOs;
using Template.Application.Interfaces.Services;

namespace Template.Application.Services
{
    public class ExampleService() : IExampleService
    {
        public Task<ExampleDto> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

using BuildingBlocks.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;

namespace RecipeMicroservice.Infrastructure.Exception
{
    public class ExceptionService(DefaultExceptionService defaultExceptionService) : IExceptionService
    {
        private readonly DefaultExceptionService _defaultExceptionService = defaultExceptionService;
        public Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            return _defaultExceptionService.HandleExceptionAsync(context, exception);
        }
    }
}

using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Exceptions
{
    public interface IExceptionService
    {
        Task HandleExceptionAsync(HttpContext context, Exception exception);
    }
}

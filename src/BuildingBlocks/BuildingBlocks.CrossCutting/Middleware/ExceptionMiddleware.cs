using BuildingBlocks.CrossCutting.Correlation;
using BuildingBlocks.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next) : BaseMiddleware (next)
    {
        private readonly RequestDelegate _next = next;
        public override Task InvokeAsync(HttpContext context)
        {
            try 
            {
                return _next(context);
            }
            catch (Exception ex)
            {
                IExceptionService exceptionService = context.RequestServices.GetRequiredService<IExceptionService>();
                return exceptionService.HandleExceptionAsync(context, ex);
            }
        }
    }
}

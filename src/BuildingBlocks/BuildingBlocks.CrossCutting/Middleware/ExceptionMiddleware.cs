using BuildingBlocks.CrossCutting.Correlation;
using BuildingBlocks.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, IExceptionService exceptionService) : BaseMiddleware (next)
    {
        private readonly RequestDelegate _next = next;
        private readonly IExceptionService _exceptionService = exceptionService;
        protected override Task InvokeAsync(HttpContext context)
        {
            try 
            {
                return _next(context);
            }
            catch (Exception ex)
            {
                return _exceptionService.HandleExceptionAsync(context, ex);
            }
        }
    }
}

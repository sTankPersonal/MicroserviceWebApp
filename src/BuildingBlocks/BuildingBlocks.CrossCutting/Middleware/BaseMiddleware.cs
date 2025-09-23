using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public abstract class BaseMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        protected virtual async Task InvokeAsync(HttpContext context)
        {
            await PreProcessAsync(context);
            await _next(context);
            await PostProcessAsync(context);
        }

        protected virtual Task PreProcessAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }

        protected virtual Task PostProcessAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}

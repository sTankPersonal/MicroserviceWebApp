using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Middleware
{
    public abstract class BaseMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public virtual async Task InvokeAsync(HttpContext context)
        {
            await PreProcessAsync(context);
            await _next(context);
            await PostProcessAsync(context);
        }

        public virtual Task PreProcessAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public virtual Task PostProcessAsync(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}

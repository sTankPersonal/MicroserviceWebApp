
using Microsoft.AspNetCore.Http;

namespace BuildingBlocks.CrossCutting.Logging
{
    public interface ILoggingService
    {
        Task LogRequestAsync(HttpContext context);
        Task LogResponseAsync(HttpContext context);
    }
}

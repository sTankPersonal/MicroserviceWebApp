using BuildingBlocks.SharedKernel.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace RecipeService.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleApiController (IDomainService): ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

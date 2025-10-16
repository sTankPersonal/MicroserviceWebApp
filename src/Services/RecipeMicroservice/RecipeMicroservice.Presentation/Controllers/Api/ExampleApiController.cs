using BuildingBlocks.SharedKernel.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace RecipeMicroservice.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleApiController (IDomainService domainService): ControllerBase
    {
        public IActionResult Index()
        {
            //return View();
            return Ok("Hello from ExampleApiController");
        }
    }
}

using BuildingBlocks.SharedKernel.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace Template.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleApiController (IDomainService domainService): ControllerBase
    {
        private IDomainService _domainService = domainService;
        public IActionResult Index()
        {
            //return View();
            return Ok("Hello from ExampleApiController");
        }
    }
}

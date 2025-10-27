using BuildingBlocks.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Domain.Specifications;

namespace RecipeMicroservice.Presentation.Controllers.Api
{
    [Route("api/[Controller]")]
    public class UnitController(IUnitService unitService) : ControllerBase
    {
        private readonly IUnitService _unitService = unitService;
        // GET api/Unit/Ajax
        [HttpGet("AjaxList")]
        public async Task<IActionResult> AjaxGetAll(FilterUnit filterUnit)
        {
            PagedResult<UnitDto> units = await _unitService.GetAllAsync(filterUnit);
            AjaxReturnDto result = new ()
            {
                results = [..units.Items.Select(u => new AjaxResultDto
                {
                    id = u.Id.ToString(),
                    text = u.Name
                })],
                pagination = new AjaxPaginationDto
                {
                    more = units.PageNumber * units.PageSize < units.TotalItems
                }
            };
            return Ok(result);
        }
    }
}

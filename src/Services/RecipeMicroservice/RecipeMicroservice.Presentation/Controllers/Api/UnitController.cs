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
        // GET api/Unit/AjaxList
        [HttpGet("Ajax/List")]
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

        //GET api/Unit/Ajax{id}
        [HttpGet("Ajax/{id}")]
        public async Task<IActionResult> GetUnit(Guid id)
        {
            UnitDto? unit = await _unitService.GetByIdAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return Ok(new AjaxResultDto
            {
                id = unit.Id.ToString(),
                text = unit.Name
            });
        }
    }
}

using BuildingBlocks.SharedKernel.Pagination;
using Microsoft.AspNetCore.Mvc;
using RecipeMicroservice.Application.DTOs.Unit;
using RecipeMicroservice.Application.Interfaces.Services;
using RecipeMicroservice.Presentation.Models.Unit;

namespace RecipeMicroservice.Presentation.Controllers.ViewModel
{
    /* GET: /Unit - Get all units and return List view
     * GET: /Unit/{id} - Get unit by id and return Details view
     * GET: /Unit/Create - Return Create view
     * GET: /Unit/Edit/{id} - Get unit by id and return Edit view
     * GET: /Unit/Delete/{id} - Get unit by id and return Delete view
     * 
     * POST: /Unit/Create - Create a new unit and redirect to Details view
     * POST: /Unit/Edit/{id} - Update a unit and redirect to Details view
     * POST: /Unit/Delete/{id} - Delete a unit and redirect to List view
     */
    [Route("[controller]")]
    public class UnitController(IUnitService unitService) : Controller
    {
        private readonly IUnitService _unitService = unitService;

        // GET: /Unit
        [HttpGet("")]
        [ActionName("List")]
        public async Task<IActionResult> GetAllUnits(FilterUnitViewModel filter)
        {
            PagedResult<UnitDto> dtos = await _unitService.GetAllAsync(FilterUnitViewModel.ToDto(filter));
            return View("List", ListUnitViewModel.FromDto(dtos).WithFilter(filter));
        }

        // GET: /Unit/{id}
        [HttpGet("{id}")]
        [ActionName("Details")]
        public async Task<IActionResult> GetUnitById(Guid id)
        {
            UnitDto? dto = await _unitService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Details", UnitViewModel.FromDto(dto));
        }

        // GET: /Unit/Create
        [HttpGet("Create")]
        [ActionName("Create")]
        public IActionResult CreateUnit()
        {
            return View("Create", new CreateUnitViewModel());
        }

        // GET: /Unit/Edit/{id}
        [HttpGet("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditUnit(Guid id)
        {
            UnitDto? dto = await _unitService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Edit", UpdateUnitViewModel.FromDto(dto));
        }

        // GET: /Unit/Delete/{id}
        [HttpGet("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteUnit(Guid id)
        {
            UnitDto? dto = await _unitService.GetByIdAsync(id);
            return dto == null ? NotFound() : View("Delete", UnitViewModel.FromDto(dto));
        }

        // POST: /Unit/Create
        [HttpPost("Create")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateUnit(CreateUnitViewModel viewModel)
        {
            CreateUnitDto dto = CreateUnitViewModel.ToDto(viewModel);
            Guid id = await _unitService.CreateAsync(dto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Unit/Edit/{id}
        [HttpPost("Edit/{id}")]
        [ActionName("Edit")]
        public async Task<IActionResult> EditUnit(Guid id, UpdateUnitViewModel viewModel)
        {
            UpdateUnitDto dto = UpdateUnitViewModel.ToDto(viewModel);
            await _unitService.UpdateAsync(id, dto);
            return RedirectToAction("Details", new { id });
        }

        // POST: /Unit/Delete/{id}
        [HttpPost("Delete/{id}")]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteUnitConfirmed(Guid id)
        {
            await _unitService.DeleteAsync(id);
            return RedirectToAction("List");
        }
    }
}

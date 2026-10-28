using DaniilBudanovKt_31_23.Filters;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Requests;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilBudanovKt_31_23.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademicGroupsController : ControllerBase
    {
        private readonly IAcademicGroupService _academicGroupService;

        public AcademicGroupsController(IAcademicGroupService academicGroupService)
        {
            _academicGroupService = academicGroupService;
        }

        [HttpPost]
        public async Task<ActionResult<AcademicGroup>> AddAcademicGroup(CreateAcademicGroupRequest request)
        {
            var group = new AcademicGroup
            {
                Name = request.Name,
                Year = request.Year,
                SpecialtyId = request.SpecialtyId,
                IsDeleted = false
            };

            var result =
                await _academicGroupService.AddAcademicGroupAsync(group);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<AcademicGroup>> UpdateAcademicGroup(UpdateAcademicGroupRequest request)
        {
            var group = new AcademicGroup
            {
                Id = request.Id,
                Name = request.Name,
                Year = request.Year,
                SpecialtyId = request.SpecialtyId
            };

            var result =
                await _academicGroupService.UpdateAcademicGroupAsync(group);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicGroup(int id)
        {
            var result =
                await _academicGroupService.DeleteAcademicGroupAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<AcademicGroup>>> GetAcademicGroups(AcademicGroupFilter filter)
        {
            var groups =
                await _academicGroupService.GetAcademicGroupsAsync(filter);

            return Ok(groups);
        }
    }
}
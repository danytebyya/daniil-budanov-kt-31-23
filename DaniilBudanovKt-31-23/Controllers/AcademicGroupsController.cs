using DaniilBudanovKt_31_23.Filters;
using DaniilBudanovKt_31_23.Models;
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

        [HttpPost("filter")]
        public async Task<ActionResult<List<AcademicGroup>>> GetAcademicGroups(AcademicGroupFilter filter)
        {
            var groups =
                await _academicGroupService.GetAcademicGroupsAsync(filter);

            return Ok(groups);
        }

        [HttpPost]
        public async Task<ActionResult<AcademicGroup>> AddAcademicGroup(AcademicGroup group)
        {
            var result =
                await _academicGroupService.AddAcademicGroupAsync(group);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<AcademicGroup>> UpdateAcademicGroup(AcademicGroup group)
        {
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
    }
}
using DaniilBudanovKt_31_23.Filters;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Implementations;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilBudanovKt_31_23.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<Subject>>> GetSubjects(
            SubjectFilter filter)
        {
            var subjects = await _subjectService.GetSubjectsAsync(filter);
            return Ok(subjects);
        }

        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubject(Subject subject)
        {
            return Ok(
                await _subjectService.AddSubjectAsync(subject));
        }

        [HttpPut]
        public async Task<ActionResult<Subject>> UpdateSubject(Subject subject)
        {
            var result =
                await _subjectService.UpdateSubjectAsync(subject);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result =
                await _subjectService.DeleteSubjectAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}

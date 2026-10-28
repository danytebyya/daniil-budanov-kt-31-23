using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Requests;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilBudanovKt_31_23.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPost]
        public async Task<ActionResult<Grade>> AddGrade(CreateGradeRequest request)
        {
            var grade = new Grade
            {
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
                Value = request.Value
            };

            var result =
                await _gradeService.AddGradeAsync(grade);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Grade>> UpdateGrade(UpdateGradeRequest request)
        {
            var grade = new Grade
            {
                Id = request.Id,
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
                Value = request.Value
            };

            var result =
                await _gradeService.UpdateGradeAsync(grade);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

using DaniilBudanovKt_31_23.Filters;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Requests;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilBudanovKt_31_23.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController: ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(CreateStudentRequest request)
        {
            var student = new Student
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                AcademicGroupId = request.AcademicGroupId,
                IsDeleted = false
            };

            var result =
                await _studentService.AddStudentAsync(student);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(UpdateStudentRequest request)
        {
            var student = new Student
            {
                LastName = request.LastName,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                AcademicGroupId = request.AcademicGroupId
            };

            var result =
                await _studentService.UpdateStudentAsync(student);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result =
                await _studentService.DeleteStudentAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<List<Student>>> GetStudents(
            StudentFilter filter)
        {
            var students = await _studentService.GetStudentsAsync(filter);
            return Ok(students);
        }
    }
}

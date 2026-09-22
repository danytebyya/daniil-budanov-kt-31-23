using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Interfaces;
using DaniilBudanovKt_31_23.Filters;
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
        [HttpPost("filter")]
        public async Task<ActionResult<List<Student>>> GetStudents(
            StudentFilter filter)
        {
            var students = await _studentService.GetStudentsAsync(filter);
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            return Ok(
                await _studentService.AddStudentAsync(student));
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
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
    }
}

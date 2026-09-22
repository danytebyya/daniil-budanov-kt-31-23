using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilBudanovKt_31_23.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceService _performanceService;

        public PerformanceController(
            IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        [HttpGet("average-by-subject-and-group")]
        public async Task<ActionResult<double>>
            GetAverageGradeBySubjectAndGroup(
                int subjectId,
                int groupId)
        {
            var average =
                await _performanceService
                    .GetAverageGradeBySubjectAndGroupAsync(
                        subjectId,
                        groupId);

            return Ok(average);
        }

        [HttpGet("student-grade")]
        public async Task<ActionResult<Grade?>>
            GetStudentGrade(
                int studentId,
                int subjectId)
        {
            var grade =
                await _performanceService
                    .GetStudentGradeAsync(
                        studentId,
                        subjectId);

            return Ok(grade);
        }

        [HttpGet("average-by-year")]
        public async Task<ActionResult<double>>
            GetAverageGradeByYear(
                int year)
        {
            var average =
                await _performanceService
                    .GetAverageGradeByYearAsync(year);

            return Ok(average);
        }

        [HttpGet("debts")]
        public async Task<ActionResult<List<Subject>>> GetDebts(string lastName)
        {
            var subjects =await _performanceService
                .GetDebtsByStudentLastNameAsync(lastName);

            return Ok(subjects);
        }
    }
}
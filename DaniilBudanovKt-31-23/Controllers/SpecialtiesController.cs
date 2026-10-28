using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Requests;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DaniilBudanovKt_31_23.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtiesController(
            ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        [HttpPost]
        public async Task<ActionResult<Specialty>> AddSpecialty(CreateSpecialtyRequest request)
        {
            var specialty = new Specialty
            {
                Name = request.Name,
                IsDeleted = false
            };

            var result =
                await _specialtyService.AddSpecialtyAsync(specialty);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Specialty>> UpdateSpecialty(UpdateSpecialtyRequest request)
        {
            var specialty = new Specialty
            {
                Id = request.Id,
                Name = request.Name
            };

            var result =
                await _specialtyService.UpdateSpecialtyAsync(specialty);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            var result =
                await _specialtyService.DeleteSpecialtyAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("students")]
        public async Task<ActionResult<List<string>>> GetStudentsBySpecialty(string specialtyName)
        {
            var students =
                await _specialtyService.GetStudentFullNameBySpecialtyAsync(specialtyName);

            return Ok(students);
        }
    }
}
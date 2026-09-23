using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaniilBudanovKt_31_23.Services.Implementations
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly StudentDbContext _context;

        public SpecialtyService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Specialty> AddSpecialtyAsync(
            Specialty specialty)
        {
            _context.Specialties.Add(specialty);

            await _context.SaveChangesAsync();

            return specialty;
        }

        public async Task<Specialty?> UpdateSpecialtyAsync(
            Specialty specialty)
        {
            var existingSpecialty =
                await _context.Specialties
                    .FirstOrDefaultAsync(x => x.Id == specialty.Id);

            if (existingSpecialty == null)
            {
                return null;
            }

            existingSpecialty.Name = specialty.Name;

            await _context.SaveChangesAsync();

            return existingSpecialty;
        }

        public async Task<bool> DeleteSpecialtyAsync(int id)
        {
            var specialty =
                await _context.Specialties
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (specialty == null)
            {
                return false;
            }

            specialty.IsDeleted = true;

            await _context.SaveChangesAsync();

            return true;
        }

        // пишем название специальности - получаем список фамилий студентов, которые обучаются на этой специальности
        public async Task<List<string>> GetStudentFullNameBySpecialtyAsync(string specialtyName)
        {
            var students = await  _context.Students
                .Where(x =>
                    x.AcademicGroup.Specialty.Name == specialtyName)
                .Select(x => x.LastName)
                .Distinct()
                .ToListAsync();

            return students;
        }
    }
}
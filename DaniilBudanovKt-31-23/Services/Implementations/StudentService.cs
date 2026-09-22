using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Filters;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaniilBudanovKt_31_23.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync(
            StudentFilter filter)
        {
            var query = _context.Students.AsQueryable();

            if (filter.AcademicGroupId.HasValue)
            {
                query = query.Where(x =>
                    x.AcademicGroupId == filter.AcademicGroupId.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.FullName))
            {
                query = query.Where(x =>
                    x.FullName.Contains(filter.FullName));
            }

            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(x =>
                    x.IsDeleted == filter.IsDeleted.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<Student?> UpdateStudentAsync(Student student)
        {
            var existingStudent =
                await _context.Students
                    .FirstOrDefaultAsync(x => x.Id == student.Id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FullName = student.FullName;
            existingStudent.AcademicGroupId = student.AcademicGroupId;

            await _context.SaveChangesAsync();

            return existingStudent;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var student = await _context.Students
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return false;
            }

            student.IsDeleted = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
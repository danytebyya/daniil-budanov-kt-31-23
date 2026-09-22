using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaniilBudanovKt_31_23.Services.Implementations
{
    public class PerformanceService : IPerformanceService
    {
        private readonly StudentDbContext _context;

        public PerformanceService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<double> GetAverageGradeBySubjectAndGroupAsync(int subjectId, int groupId)
        {
            var query = _context.Grades.Where(x =>
                x.SubjectId == subjectId &&
                x.Student.AcademicGroupId == groupId);

            if (!await query.AnyAsync())
            {
                return 0;
            }

            return await query.AverageAsync(x => x.Value);
        }

        public async Task<Grade?> GetStudentGradeAsync(int studentId, int subjectId)
        {
            return await _context.Grades.FirstOrDefaultAsync(x =>
                x.StudentId == studentId &&
                x.SubjectId == subjectId);
        }

        public async Task<double> GetAverageGradeByYearAsync(int year)
        {
            var query = _context.Grades.Where(x =>
                x.Student.AcademicGroup.Year == year);

            if (!await query.AnyAsync())
            {
                return 0;
            }

            return await query.AverageAsync(x => x.Value);
        }

        public async Task<List<Subject>> GetDebtsByStudentLastNameAsync(string fullName)
        {
            return await _context.Grades
                .Where(x =>
                    x.Student.FullName == fullName &&
                    x.Value <= 2)
                .Select(x => x.Subject)
                .Distinct()
                .ToListAsync();
        }
    }
}
using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaniilBudanovKt_31_23.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly StudentDbContext _context;

        public GradeService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Grade> AddGradeAsync(Grade grade)
        {
            _context.Grades.Add(grade);

            await _context.SaveChangesAsync();

            return grade;
        }

        public async Task<Grade?> UpdateGradeAsync(Grade grade)
        {
            var existingGrade =
                await _context.Grades
                    .FirstOrDefaultAsync(x => x.Id == grade.Id);

            if (existingGrade == null)
            {
                return null;
            }

            existingGrade.Value = grade.Value;
            existingGrade.StudentId = grade.StudentId;
            existingGrade.SubjectId = grade.SubjectId;

            await _context.SaveChangesAsync();

            return existingGrade;
        }
    }
}

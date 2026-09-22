using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Services.Interfaces;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Filters;
using Microsoft.EntityFrameworkCore;


namespace DaniilBudanovKt_31_23.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private readonly StudentDbContext _context;

        public SubjectService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetSubjectsAsync(
            SubjectFilter filter)
        {
            var query = _context.Subjects.AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter.Direction))
            {
                query = query.Where(x =>
                    x.Name.Contains(filter.Direction));
            }
            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(x =>
                    x.IsDeleted == filter.IsDeleted.Value);
            }
            return await query.ToListAsync();
        }

        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);

            await _context.SaveChangesAsync();

            return subject;
        }

        public async Task<Subject?> UpdateSubjectAsync(Subject subject)
        {
            var existingSubject = await _context.Subjects
                .FirstOrDefaultAsync(x => x.Id == subject.Id);

            if (existingSubject == null)
            {
                return null;
            }

            existingSubject.Name = subject.Name;
            existingSubject.Direction = subject.Direction;

            await _context.SaveChangesAsync();

            return existingSubject;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects
                .FirstOrDefaultAsync(x => x.Id == id);

            if (subject == null)
            {
                return false;
            }

            subject.IsDeleted = true;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

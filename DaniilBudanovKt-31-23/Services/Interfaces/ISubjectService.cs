using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Filters;

namespace DaniilBudanovKt_31_23.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetSubjectsAsync(
            SubjectFilter filter
        );

        Task<Subject> AddSubjectAsync(Subject subject);

        Task<Subject?> UpdateSubjectAsync(Subject subject);

        Task<bool> DeleteSubjectAsync(int id);
    }
}

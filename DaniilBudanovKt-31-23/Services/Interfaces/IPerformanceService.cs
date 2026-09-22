using DaniilBudanovKt_31_23.Models;

namespace DaniilBudanovKt_31_23.Services.Interfaces
{
    public interface IPerformanceService
    {
        Task<double> GetAverageGradeBySubjectAndGroupAsync(int subjectId, int groupId);

        Task<Grade?> GetStudentGradeAsync(int studentId, int subjectId);

        Task<double> GetAverageGradeByYearAsync(int year);

        Task<List<Subject>> GetDebtsByStudentLastNameAsync(string fullName);
    }
}
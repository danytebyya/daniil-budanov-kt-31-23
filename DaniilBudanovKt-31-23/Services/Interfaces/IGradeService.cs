using DaniilBudanovKt_31_23.Models;

namespace DaniilBudanovKt_31_23.Services.Interfaces
{
    public interface IGradeService
    {
        Task<Grade> AddGradeAsync(Grade grade);

        Task<Grade?> UpdateGradeAsync(Grade grade);
    }
}
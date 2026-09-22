using DaniilBudanovKt_31_23.Filters;
using DaniilBudanovKt_31_23.Models;

namespace DaniilBudanovKt_31_23.Services.Interfaces
{
    public interface IAcademicGroupService
    {
        Task<List<AcademicGroup>> GetAcademicGroupsAsync(
            AcademicGroupFilter filter
        );

        Task<AcademicGroup> AddAcademicGroupAsync(AcademicGroup group);

        Task<AcademicGroup?> UpdateAcademicGroupAsync(AcademicGroup group);

        Task<bool> DeleteAcademicGroupAsync(int id);
    }
}

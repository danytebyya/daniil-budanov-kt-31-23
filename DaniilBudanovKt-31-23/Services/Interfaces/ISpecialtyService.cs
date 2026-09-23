using DaniilBudanovKt_31_23.Models;

namespace DaniilBudanovKt_31_23.Services.Interfaces
{
    public interface ISpecialtyService
    {
        Task<Specialty> AddSpecialtyAsync(Specialty specialty);

        Task<Specialty?> UpdateSpecialtyAsync(Specialty specialty);

        Task<bool> DeleteSpecialtyAsync(int id);

        Task<List<string>> GetStudentFullNameBySpecialtyAsync(string specialtyName);
    }
}
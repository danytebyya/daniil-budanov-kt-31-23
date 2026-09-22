using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Filters;

namespace DaniilBudanovKt_31_23.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync(
            StudentFilter filter
        );

        Task<Student> AddStudentAsync(Student student);

        Task<Student?> UpdateStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(int id);
    }
}

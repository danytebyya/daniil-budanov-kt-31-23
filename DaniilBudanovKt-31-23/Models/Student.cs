namespace DaniilBudanovKt_31_23.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public int AcademicGroupId { get; set; }

        public AcademicGroup AcademicGroup { get; set; } = null!;
    }
}
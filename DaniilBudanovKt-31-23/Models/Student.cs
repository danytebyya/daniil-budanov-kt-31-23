namespace DaniilBudanovKt_31_23.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public bool IsDeleted { get; set; }

        public int AcademicGroupId { get; set; }

        public AcademicGroup AcademicGroup { get; set; } = null!;
    }
}
namespace DaniilBudanovKt_31_23.Models
{
    public class AcademicGroup
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Specialty { get; set; } = null!;

        public int Year { get; set; }

        public bool IsDeleted { get; set; }

        public List<Student> Students { get; set; } = [];
    }
}
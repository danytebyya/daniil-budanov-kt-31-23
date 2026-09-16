namespace DaniilBudanovKt_31_23.Models
{
    public class AcademicGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public bool IsDeleted { get; set; }

        public int SpecialtyId { get; set; }

        public Specialty Specialty { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
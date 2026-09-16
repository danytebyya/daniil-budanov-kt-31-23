namespace DaniilBudanovKt_31_23.Models
{
    public class Credit
    {
        public int Id { get; set; }

        public bool IsPassed { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;

        public int SubjectId { get; set; }

        public Subject Subject { get; set; } = null!;
    }
}
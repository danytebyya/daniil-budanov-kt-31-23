namespace DaniilBudanovKt_31_23.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Direction { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}
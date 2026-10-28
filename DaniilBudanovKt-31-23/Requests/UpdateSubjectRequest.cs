namespace DaniilBudanovKt_31_23.Requests
{
    public class UpdateSubjectRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Direction { get; set; } = null!;
    }
}

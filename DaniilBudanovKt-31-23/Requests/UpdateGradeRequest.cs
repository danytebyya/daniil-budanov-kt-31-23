namespace DaniilBudanovKt_31_23.Requests
{
    public class UpdateGradeRequest
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public int Value { get; set; }
    }
}

namespace DaniilBudanovKt_31_23.Requests
{
    public class UpdateStudentRequest
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public int AcademicGroupId { get; set; }
    }
}

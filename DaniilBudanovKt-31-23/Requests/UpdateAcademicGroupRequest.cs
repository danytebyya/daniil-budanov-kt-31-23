namespace DaniilBudanovKt_31_23.Requests
{
    public class UpdateAcademicGroupRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Year { get; set; }

        public int SpecialtyId { get; set; }
    }
}
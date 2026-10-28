namespace DaniilBudanovKt_31_23.Validators
{
    public class SpecialtyValidator
    {
        public bool IsValidSpecialtyName(string? name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
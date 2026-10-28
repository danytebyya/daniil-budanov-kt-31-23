using Xunit;
using DaniilBudanovKt_31_23.Validators;

namespace DaniilBudanovKt_31_23.Tests.UnitTests
{
    public class SpecialtyValidatorTests
    {
        [Theory]
        [InlineData("Программная инженерия", true)]
        [InlineData("Информатика", true)]
        [InlineData("", false)]
        [InlineData("   ", false)]
        [InlineData(null, false)]
        public void IsValidSpecialtyName_DifferentNames_ExpectedResult(
            string? name, bool expected)
        {
            // Arrange
            var validator = new SpecialtyValidator();

            // Act
            bool result = validator.IsValidSpecialtyName(name);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

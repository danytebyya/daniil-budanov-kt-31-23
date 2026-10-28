using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Services.Implementations;
using Xunit;

namespace DaniilBudanovKt_31_23.Tests.IntegrationTests
{
    [Collection("SharedDatabase")]
    public class PerformanceServiceIntegrationTests
    {
        private readonly TestDatabaseFixture _fixture;

        public PerformanceServiceIntegrationTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAverageGradeBySubjectAndGroupAsync_MathGroup1_Returns4Point5()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var service = new PerformanceService(context);

            int subjectId = 1;
            int groupId = 1;

            // Act
            double result = await service
                .GetAverageGradeBySubjectAndGroupAsync(subjectId, groupId);

            // Assert
            Assert.Equal(4.5, result);
        }

        [Fact]
        public async Task GetStudentGradeAsync_IvanovMath_ReturnsFive()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var service = new PerformanceService(context);

            int studentId = 1;
            int subjectId = 1;

            // Act
            var result = await service
                .GetStudentGradeAsync(studentId, subjectId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, result.Value);
        }

        [Fact]
        public async Task GetAverageGradeByYearAsync_2023_Returns4Point67()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var service = new PerformanceService(context);

            int year = 2023;

            // Act
            double result = await service
                .GetAverageGradeByYearAsync(year);

            // Assert
            Assert.Equal(14.0 / 3, result, 2);
        }
    }
}

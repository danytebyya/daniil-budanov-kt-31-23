
using DaniilBudanovKt_31_23.Services.Implementations;
using Xunit;

namespace DaniilBudanovKt_31_23.Tests.IntegrationTests
{
    [Collection("SharedDatabase")]
    public class SpecialtyServiceIntegrationTests
    {
        private readonly TestDatabaseFixture _fixture;

        public SpecialtyServiceIntegrationTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetStudentFullNameBySpecialtyAsync_ProgramEngineering_TwoStudents()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var service = new SpecialtyService(context);

            // Act
            var result = await service
                .GetStudentFullNameBySpecialtyAsync("Программная инженерия");

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains("Иванов", result);
            Assert.Contains("Петров", result);
            Assert.DoesNotContain("Сидоров", result);
        }

        [Fact]
        public async Task GetStudentFullNameBySpecialtyAsync_DeletedStudent_Excluded()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var service = new SpecialtyService(context);

            // Act
            var result = await service
                .GetStudentFullNameBySpecialtyAsync("Программная инженерия");

            // Assert
            Assert.DoesNotContain("Смирнов", result);
        }

        [Fact]
        public async Task GetStudentFullNameBySpecialtyAsync_DuplicateLastNames_UniqueResult()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var service = new SpecialtyService(context);

            // Act
            var result = await service
                .GetStudentFullNameBySpecialtyAsync("Программная инженерия");

            // Assert
            Assert.Equal(1, result.Count(x => x == "Иванов"));
        }

        [Fact]
        public async Task GetStudentFullNameBySpecialtyAsync_UnknownSpecialty_EmptyList()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            var service = new SpecialtyService(context);

            // Act
            var result = await service
                .GetStudentFullNameBySpecialtyAsync("Несуществующая специальность");

            // Assert
            Assert.Empty(result);
        }
    }
}

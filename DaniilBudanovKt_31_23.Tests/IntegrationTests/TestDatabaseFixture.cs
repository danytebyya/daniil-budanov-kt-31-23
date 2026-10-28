using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Models;
using Microsoft.EntityFrameworkCore;

namespace DaniilBudanovKt_31_23.Tests.IntegrationTests
{
    public class TestDatabaseFixture : IDisposable
    {
        private readonly DbContextOptions<StudentDbContext> _options;

        public TestDatabaseFixture()
        {
            _options = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase("StudentIntegrationTestDb")
                .Options;

            using var context = CreateContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            SeedDatabase(context);
        }

        public StudentDbContext CreateContext()
        {
            return new StudentDbContext(_options);
        }

        private static void SeedDatabase(StudentDbContext context)
        {
            var specialty1 = new Specialty
            {
                Id = 1,
                Name = "Программная инженерия"
            };

            var specialty2 = new Specialty
            {
                Id = 2,
                Name = "Информатика"
            };

            context.Specialties.AddRange(specialty1, specialty2);

            var group1 = new AcademicGroup
            {
                Id = 1,
                Name = "КТ-31-23",
                Year = 2023,
                SpecialtyId = 1
            };

            var group2 = new AcademicGroup
            {
                Id = 2,
                Name = "КТ-41-23",
                Year = 2024,
                SpecialtyId = 2
            };

            context.AcademicGroups.AddRange(group1, group2);


            context.Students.AddRange(
                new Student
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    AcademicGroupId = 1
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Пётр",
                    LastName = "Петров",
                    AcademicGroupId = 1
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Алексей",
                    LastName = "Сидоров",
                    AcademicGroupId = 2
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Андрей",
                    LastName = "Смирнов",
                    AcademicGroupId = 1,
                    IsDeleted = true
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Дмитрий",
                    LastName = "Иванов",
                    AcademicGroupId = 1
                }
            );


            context.Subjects.AddRange(
                new Subject
                {
                    Id = 1,
                    Name = "Математика",
                    Direction = "Техническое"
                },
                new Subject
                {
                    Id = 2,
                    Name = "Программирование",
                    Direction = "Техническое"
                }
            );

            context.Grades.AddRange(
                new Grade
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    Value = 5
                },
                new Grade
                {
                    Id = 2,
                    StudentId = 2,
                    SubjectId = 1,
                    Value = 4
                },
                new Grade
                {
                    Id = 3,
                    StudentId = 3,
                    SubjectId = 1,
                    Value = 3
                },
                new Grade
                {
                    Id = 4,
                    StudentId = 1,
                    SubjectId = 2,
                    Value = 5
                }
            );

            context.SaveChanges();
        }

        public void Dispose()
        {
            using var context = CreateContext();
            context.Database.EnsureDeleted();
        }
    }

    [CollectionDefinition("SharedDatabase")]
    public class SharedDatabaseCollection : ICollectionFixture<TestDatabaseFixture>
    {
    }
}

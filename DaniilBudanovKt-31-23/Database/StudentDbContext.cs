using DaniilBudanovKt_31_23.Database.Configurations;
using DaniilBudanovKt_31_23.Models;
using Microsoft.EntityFrameworkCore;

namespace DaniilBudanovKt_31_23.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {

        }

        public DbSet<AcademicGroup> AcademicGroups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Specialty> Specialties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcademicGroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
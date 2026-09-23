using DaniilBudanovKt_31_23.Helpers;
using DaniilBudanovKt_31_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaniilBudanovKt_31_23.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("students");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType(ColumnType.Int);

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.MiddleName)
                .HasColumnName("middle_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType(ColumnType.Bool)
                .IsRequired();

            builder.Property(x => x.AcademicGroupId)
                .HasColumnName("academic_group_id")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.HasOne(x => x.AcademicGroup)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.AcademicGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
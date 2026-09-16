using DaniilBudanovKt_31_23.Helpers;
using DaniilBudanovKt_31_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaniilBudanovKt_31_23.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("grades");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType(ColumnType.Int);

            builder.Property(x => x.Value)
                .HasColumnName("value")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(x => x.StudentId)
                .HasColumnName("student_id")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(x => x.SubjectId)
                .HasColumnName("subject_id")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.HasOne(x => x.Student)
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subject)
                .WithMany()
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
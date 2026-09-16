using DaniilBudanovKt_31_23.Helpers;
using DaniilBudanovKt_31_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaniilBudanovKt_31_23.Database.Configurations
{
    public class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> builder)
        {
            builder.ToTable("credits");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType(ColumnType.Int);

            builder.Property(x => x.IsPassed)
                .HasColumnName("is_passed")
                .HasColumnType(ColumnType.Bool)
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
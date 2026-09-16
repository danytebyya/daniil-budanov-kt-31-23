using DaniilBudanovKt_31_23.Helpers;
using DaniilBudanovKt_31_23.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaniilBudanovKt_31_23.Database.Configurations
{
    public class AcademicGroupConfiguration : IEntityTypeConfiguration<AcademicGroup>
    {
        public void Configure(EntityTypeBuilder<AcademicGroup> builder)
        {
            builder.ToTable("academic_groups");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType(ColumnType.Int);

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Specialty)
                .HasColumnName("specialty")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Year)
                .HasColumnName("year")
                .HasColumnType(ColumnType.Int)
                .IsRequired();

            builder.Property(x => x.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType(ColumnType.Bool)
                .IsRequired();
        }
    }
}
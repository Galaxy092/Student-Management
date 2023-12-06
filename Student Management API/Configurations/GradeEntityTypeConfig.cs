using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentLib;

namespace Student_Management_API.Configurations
{
    public class GradeEntityTypeConfig : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("Grades");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired(true)
                .HasColumnName(nameof(Grade.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                .IsUnicode(false)
                ;

            builder.Property(x => x.Id)
                .IsRequired(true)
                .HasColumnName(nameof(Grade.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                .IsUnicode(false)
                ;

            builder.Property(x => x.Value)
                .IsRequired(true)
                .HasColumnName(nameof(Grade.Value))
                .HasColumnType("varchar(1)")
                ;

            builder.Property(x => x.CreatedOn)
                .IsRequired(false)
                .HasColumnName(nameof(Grade.CreatedOn))
                .HasColumnType("datetime")
                ;

            builder.Property(x => x.LastUpdatedOn)
                .IsRequired(false)
                .HasColumnName(nameof(Grade.LastUpdatedOn))
                .HasColumnType("datetime")
                ;

            builder.HasOne(x => x.Student)
                   .WithMany(p => p.Grades)
                   .HasForeignKey(x => x.StudentId)
                   .HasPrincipalKey(x => x.Id)
                   .OnDelete(DeleteBehavior.NoAction)
                   ;
        }
    }
}

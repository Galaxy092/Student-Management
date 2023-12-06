using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentLib;

namespace Student_Management_API.Configurations
{
    public class StudentEntityConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Code).IsUnique(true);

            builder.Property(x => x.Id)
                .IsRequired(true)
                .HasColumnName(nameof(Student.Id))
                .HasColumnType("varchar")
                .HasMaxLength(36)
                .IsUnicode(false)
                ;
            builder.Property(x => x.Code)
                .IsRequired(true)
                .HasColumnName(nameof(Student.Code))
                .HasColumnType("nvarchar")
                .HasMaxLength(20)
                .IsUnicode(true)
                ;
            builder.Property(x => x.Name)
                .IsRequired(false)
                .HasColumnName(nameof(Student.Name))
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsUnicode(true)
                ;
            builder.Property(x => x.Major)
                .IsRequired(true)
                .HasColumnName(nameof(Student.Major))
                .HasColumnType("tinyint")
                ;
            builder.Property(x => x.CreatedOn)
                .IsRequired(false)
                .HasColumnName(nameof(Student.CreatedOn))
                .HasColumnType("datetime")
                ;
            builder.Property(x => x.LastUpdatedOn)
                .IsRequired(false)
                .HasColumnName(nameof(Student.LastUpdatedOn))
                .HasColumnType("datetime")
                ;
        }
    }
}

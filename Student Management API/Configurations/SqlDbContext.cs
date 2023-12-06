using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentLib;

namespace Student_Management_API.Configurations
{
    public class SqlDbContext : DbContext, IDbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            Students = Set<Student>();
            Grades = Set<Grade>();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityConfig());
            SeedProductData(modelBuilder.Entity<Student>());
        }

        private void SeedProductData(EntityTypeBuilder<Student> entityTypeBuilder)
        {
            var reqs = new List<StudentCreateReq>()
        {
            new()
            {
                Code = "STU001",
                Name = "Penh Polydet",
                Major= "CS"
            },
            new()
            {
                Code = "STU002",
                Name = "Penh Vireak",
                Major= "ITE"
            },
            new()
            {
                Code = "STU003",
                Name = "Penh Veasna",
                Major= "Math"
            }
        };
            entityTypeBuilder.HasData(reqs.Select(x => x.ToEntity()));
        }
    }
}

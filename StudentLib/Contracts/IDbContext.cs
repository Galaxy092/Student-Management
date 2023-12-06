using Microsoft.EntityFrameworkCore;

namespace StudentLib
{
    public interface IDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Grade> Grades { get; set; }
        int SaveChanges();
    }
}

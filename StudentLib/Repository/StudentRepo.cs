

namespace StudentLib
{
    public class StudentRepo : IStudentRepo
    {
        public IDbContext _context = default!;

        public IDbContext DbContext => _context;

        public StudentRepo(IDbContext context)
        {
            _context = context;
        }

        public void Create(Student entity)
        {
            try
            {
                _context.Students.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create > {ex.Message}");
            }
        }

        public bool Delete(Student entity)
        {
            try
            {
                _context.Students.Remove(entity);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete > {ex.Message}");
            }
        }

        public IQueryable<Student> GetQueryable()
        {
            return _context.Students.AsQueryable();
        }

        public bool Update(Student entity)
        {
            try
            {
                _context.Students.Update(entity);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update > {ex.Message}");
            }
        }
    }
}


namespace StudentLib
{
    public class GradeRepo : IGradeRepo
    {
        public IDbContext _context = default!;

        public IDbContext DbContext => _context;

        public GradeRepo(IDbContext context)
        {
            _context = context;
        }

        public void Create(Grade entity)
        {
            try
            {
                _context.Grades.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create > {ex.Message}");
            }
        }

        public bool Delete(Grade entity)
        {
            try
            {
                _context.Grades.Remove(entity);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete > {ex.Message}");
            }
        }

        public IQueryable<Grade> GetQueryable()
        {
            return _context.Grades.AsQueryable();
        }

        public bool Update(Grade entity)
        {
            try
            {
                _context.Grades.Update(entity);
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update > {ex.Message}");
            }
        }
    }
}

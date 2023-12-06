
using Microsoft.EntityFrameworkCore;

namespace StudentLib
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepo _repo = default!;
        private readonly IStudentRepo _studentRepo;

        public GradeService(IGradeRepo repo, IStudentRepo studentRepo)
        {
            _repo = repo;
            _studentRepo = studentRepo;
        }

        public bool Exist(string key)
        {
            return _repo.GetQueryable().Any(x => x.Id == key);
        }
        public Result<string?> Create(GradeCreateReq req)
        {
            var foundProduct = _studentRepo.GetQueryable().FirstOrDefault(x => x.Id == req.StudentKey || x.Code.ToLower() == req.StudentKey.ToLower());
            if (foundProduct == null)
                return Result<string?>.Fail($"The product with the id/code, {req.StudentKey}, does not exist");

            req.StudentKey = foundProduct.Id;

            Grade entity = req.ToEntity();
            try
            {
                _repo.Create(entity);
                return Result<string?>.Success(entity.Id, "Successfully created");
            }
            catch (Exception ex)
            {
                return Result<string?>.Fail(ex.Message);
            }
        }

        public Result<List<GradeResponse>> ReadAll()
        {
            var result = _repo.GetQueryable()
                              .Include(x => x.Student)
                              .Select(x => x.ToResponse())
                              .ToList();
            return Result<List<GradeResponse>>.Success(result);
        }
        public Result<GradeResponse?> Read(string key)
        {
            var entity = _repo.GetQueryable()
                .Include(x => x.Student)
                .FirstOrDefault(x => x.Id == key);
            return Result<GradeResponse?>.Success(entity?.ToResponse());
        }

        public Result<string?> Update(GradeUpdateReq req)
        {
            var entity = _repo.GetQueryable()
                             .FirstOrDefault(x => x.Id == req.Id);
            if (entity == null)
                return Result<string?>.Fail($"No pricing with id, {req.Id}");

            var foundProduct = _studentRepo.GetQueryable().FirstOrDefault(x => x.Id == req.StudentKey || x.Code.ToLower() == req.StudentKey.ToLower());
            if (foundProduct == null)
                return Result<string?>.Fail($"No product with id/code, {req.StudentKey}");

            req.StudentKey = foundProduct.Id;
            entity.Copy(req);
            try
            {
                var result = _repo.Update(entity);
                return result == true ? Result<string?>.Success(entity.Id, "Successfully updated")
                        : Result<string?>.Fail($"Failed to update pricing with id, {req.Id}");
            }
            catch (Exception ex)
            {
                return Result<string?>.Fail(ex.Message);
            }
        }
        public Result<string?> Delete(string key)
        {
            var entity = _repo.GetQueryable()
                             .FirstOrDefault(x => x.Id == key);
            if (entity == null)
                return Result<string?>.Fail($"No pricing with id, {key}");
            try
            {
                var result = _repo.Delete(entity);
                return result == true ?
                          Result<string?>.Success(entity.Id, "Successfully deleted")
                        : Result<string?>.Fail($"Failed to delete pricing with id, {key}");
            }
            catch (Exception ex)
            {
                return Result<string?>.Fail(ex.Message);
            }
        }
    }
}

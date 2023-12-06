using Microsoft.EntityFrameworkCore;

namespace StudentLib
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _repo = default!;

        public StudentService(IStudentRepo repo) { _repo = repo; }

        public bool Exist(string key)
        {
            return _repo.GetQueryable().Any(x => x.Id == key || x.Code.ToLower() == key.ToLower());
        }
        public Result<string?> Create(StudentCreateReq req)
        {
            if (Exist(req.Code) == true)
                return Result<string?>.Fail($"Student with the id, {req.Code}, does already exist");
            Student entity = req.ToEntity();
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

        public Result<List<StudentResponse>> ReadAll()
        {
            var result = _repo.GetQueryable()
                              .Include(x=>x.Grades!)
                              .Select(x => x.ToResponse())
                              .ToList();
            return Result<List<StudentResponse>>.Success(result);
        }
        public Result<StudentResponse?> Read(string key)
        {
            var entity = _repo.GetQueryable()
                              .FirstOrDefault(x => x.Id == key || x.Code.ToLower() == key.ToLower());
            if (entity == null)
                return Result<StudentResponse?>.Fail($"No student with id/stuid, {key}");
            return Result<StudentResponse?>.Success(entity?.ToResponse());
        }

        public Result<string?> Update(StudentUpdateReq req)
        {
            var entity = _repo.GetQueryable()
                             .FirstOrDefault(x => (x.Id == req.Key) || (x.Code.ToLower() == req.Key.ToLower()));
            if (entity == null)
                return Result<string?>.Fail($"No student with id/stuid, {req.Key}");
            entity.Copy(req);
            try
            {
                var result = _repo.Update(entity);
                return result == true ? Result<string?>.Success(entity.Id, "Successfully updated")
                        : Result<string?>.Fail($"Failed to update student with id/stuid, {req.Key}");
            }
            catch (Exception ex)
            {
                return Result<string?>.Fail(ex.Message);
            }
        }
        public Result<string?> Delete(string key)
        {
            var entity = _repo.GetQueryable()
                             .FirstOrDefault(x => (x.Id == key) || (x.Code.ToLower() == key.ToLower()));
            if (entity == null)
                return Result<string?>.Fail($"No student with id/stuid, {key}");
            try
            {
                var result = _repo.Delete(entity);
                return result == true ?
                          Result<string?>.Success(entity.Id, "Successfully deleted")
                        : Result<string?>.Fail($"Failed to delete student with id/stuid, {key}");
            }
            catch (Exception ex)
            {
                return Result<string?>.Fail(ex.Message);
            }
        }
    }
}

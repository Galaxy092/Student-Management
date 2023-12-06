
namespace StudentLib
{
    public static class GradeExtensions
    {
        public static GradeResponse ToResponse(this Grade grade)
        {
            return new GradeResponse()
            {
                Id = grade.Id,
                StudentCode = grade.Student!.Code,
                Value = grade.Value,
            };
        }
        public static Grade ToEntity(this GradeCreateReq req)
        {
            return new Grade()
            {
                Id = Guid.NewGuid().ToString(),
                StudentId = req.StudentKey,
                Value = req.Value,
            };
        }
        public static void Copy(this Grade grade, GradeUpdateReq req)
        {
            grade.StudentId = req.StudentKey;
            grade.Value = req.Value;
            grade.StudentId = req.StudentKey;
        }
    }
}

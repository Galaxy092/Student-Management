
namespace StudentLib
{
    public static class StudentExtensions
    {
        public static StudentResponse ToResponse(this Student stu)
        {
            return new StudentResponse()
            {
                Id = stu.Id,
                Code = stu.Code,
                Name = stu.Name,
                Major = Enum.GetName<Major>(stu.Major),
                Grade = stu.Grades!.LastOrDefault()?.Value
            };
        }
        public static Student ToEntity(this StudentCreateReq req)
        {
            var major = Major.None;
            Major.TryParse(req.Major, out major);
            return new Student()
            {
                Id = Guid.NewGuid().ToString(),
                Code = req.Code,
                Name = req.Name,
                Major = major,
                CreatedOn = DateTime.Now,
                LastUpdatedOn = null
            };
        }
        public static void Copy(this Student stu, StudentUpdateReq req)
        {
            var major = Major.None;
            Major.TryParse(req.Major, out major);
            stu.Name = req.Name;
            stu.Major = major;
        }
    }
}

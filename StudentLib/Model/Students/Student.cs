
namespace StudentLib
{
    public class Student : StudentBase, IKey
    {
        public string Id { get; set; } = default!;
        public string Code { get; set; } = default!;
        public Major Major { get; set; } = Major.None;
        public DateTime? CreatedOn { get; set; } = default;
        public DateTime? LastUpdatedOn { get; set; } = default;
        public List<Grade>? Grades { get; set; } = default;
    }
}

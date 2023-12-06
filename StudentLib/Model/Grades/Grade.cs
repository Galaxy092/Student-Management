
namespace StudentLib
{
    public class Grade : GradeBase, IKey
    {
        public string Id { get; set; } = default!;
        public string StudentId { get; set; } = default!;
        public DateTime? CreatedOn { get; set; } = default!;
        public DateTime? LastUpdatedOn { get; set; } = default!;

        public Student? Student { get; set; } = default;
    }
}

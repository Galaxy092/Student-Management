
namespace StudentLib
{
    public class StudentResponse : 
        StudentBase, 
        IResponse
    {
        public string? Id { get; set; } = default;
        public string Code { get; set; } = default!;
        public string? Major { get; set; } = default;
        public char? Grade { get; set; } = default;
    }
}

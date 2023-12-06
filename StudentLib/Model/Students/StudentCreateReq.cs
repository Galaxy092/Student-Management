
namespace StudentLib
{
    public class StudentCreateReq : 
        StudentBase, 
        ICreateReq
    {
        public string Code { get; set; } = default!;
        public string? Major { get; set; } = default;
    }
}

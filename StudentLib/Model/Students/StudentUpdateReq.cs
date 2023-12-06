
namespace StudentLib
{
    public class StudentUpdateReq : 
        StudentBase, 
        IUpdateReq
    {
        public string Key { get; set; } = default!;
        public string? Major { get; set; } = default!;
    }
}

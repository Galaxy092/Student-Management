
namespace StudentLib
{
    public class GradeCreateReq : 
        GradeBase, 
        ICreateReq
    {
        public string StudentKey { get; set; } = default!;
    }
}

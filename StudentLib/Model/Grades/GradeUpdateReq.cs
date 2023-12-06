
namespace StudentLib
{
    public class GradeUpdateReq :
        GradeBase,
        IUpdateReq,
        IKey
    {
        public string Id { get; set; } = default!;
        public string StudentKey { get; set; } = default!;
    }
}

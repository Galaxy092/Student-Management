
namespace StudentLib
{
    public class GradeResponse : 
        GradeBase, 
        IResponse
    {
        public string? Id { get; set; } = default;
        public string StudentCode { get; set; } = default!;
    }
}

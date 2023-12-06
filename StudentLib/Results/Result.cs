namespace StudentLib
{
    public class Result<T>
    {
        public bool Succeded { get; set; } = default!;
        public string? Message { get; set; } = default!;
        public T? Data { get; set; } = default!;

        public static Result<T> Success(T? Data, string? Message = null)
        {
            return new Result<T>()
            {
                Succeded = true,
                Data = Data,
                Message = Message,
            };
        }

        public static Result<T> Fail(string? Message = null)
        {
            return new Result<T>()
            {
                Succeded = false,
                Message = Message,
                Data = default
            };
        }
    }
}

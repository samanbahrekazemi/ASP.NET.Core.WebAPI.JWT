namespace Presentation.Models
{
    public class Result
    {
        public Result()
        {

        }

        public Result(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public bool Succeeded { get; set; }
        public string? Message { get; set; }
    }
}

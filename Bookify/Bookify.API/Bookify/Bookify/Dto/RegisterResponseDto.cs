namespace Bookify.Dto
{
    public class RegisterResponseDto
    {
        public bool IsSuccessfulRegister { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}

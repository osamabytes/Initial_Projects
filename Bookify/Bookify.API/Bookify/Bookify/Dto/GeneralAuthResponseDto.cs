namespace Bookify.Dto
{
    public class GeneralAuthResponseDto
    {
        public Boolean IsAllowed { get; set; }
        public List<string>? Errors { get; set; }
    }
}

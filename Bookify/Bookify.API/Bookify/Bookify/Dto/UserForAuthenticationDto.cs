using System.ComponentModel.DataAnnotations;

namespace Bookify.Dto
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email is Required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string? Password { get; set; }
    }
}

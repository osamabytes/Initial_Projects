using System.ComponentModel.DataAnnotations;

namespace Bookify.Dto
{
    public class UserRegistrationDto
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "The Password and Confirmation Password do not match")]
        public string? ConfirmPassword { get; set; }
    }
}

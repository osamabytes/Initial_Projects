using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        // navigation properties
        /*public User_Type? User_Type { get; set; }

        public User_Bookshop? User_Bookshop { get; set; }

        public List<Review>? reviews { get; set; } */

    }
}

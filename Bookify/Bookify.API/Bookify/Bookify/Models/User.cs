using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Timestamp]
        public byte[]? CreatedAt { get; set; }

        // navigation properties
        public User_Type? User_Type { get; set; }

        public User_Bookshop? User_Bookshop { get; set; }

        public List<Review>? reviews { get; set; }

    }
}

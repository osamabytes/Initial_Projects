using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Bookshop
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [Timestamp]
        public byte[]? CreatedAt { get; set; }

        // navigation properties
        public User_Bookshop? User_Bookshop { get; set; }

        public List<Book_Bookshop>? Book_Bookshops { get; set; }
    }
}

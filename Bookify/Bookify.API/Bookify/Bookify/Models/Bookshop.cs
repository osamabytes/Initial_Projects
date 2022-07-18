using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Bookshop
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }

        // navigation properties
        /*public User_Bookshop? User_Bookshop { get; set; }

        public List<Book_Bookshop>? Book_Bookshops { get; set; }*/
    }
}

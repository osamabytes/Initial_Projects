using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public string? Pic1 { get; set; }
        public string? Pic2 { get; set; }

        // navigation properties
        /*public List<Book_Category>? Book_Categories { get; set; }

        public List<Review>? reviews { get; set; }

        public Book_Bookshop? Book_Bookshop { get; set; }*/
    }
}

using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        // navigation properties
        /*public List<Book_Category>? Book_Categories { get; set; }*/
    }
}

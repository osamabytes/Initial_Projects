using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Timestamp]
        public byte[]? CreatedAt { get; set; }

        // navigation properties
        public List<Book_Category>? Book_Categories { get; set; }
    }
}

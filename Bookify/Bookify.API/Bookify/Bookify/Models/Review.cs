using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Review
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 5)]
        public decimal Rating { get; set; }
        [Required]
        public string? Reviews { get; set; }

        // navigation properties
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid Bookid { get; set; }
        public Book? Book { get; set; }
    }
}

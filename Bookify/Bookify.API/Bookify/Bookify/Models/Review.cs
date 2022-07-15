using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Review
    {
        public Guid Id { get; set; }

        [Range(0, 5)]
        public decimal Rating { get; set; }
        public string? Reviews { get; set; }
        [Timestamp]
        public byte[]? CreatedAt { get; set; }

        // navigation properties
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid Bookid { get; set; }
        public Book? Book { get; set; }
    }
}

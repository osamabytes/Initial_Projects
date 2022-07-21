using Bookify.Data;
using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Review
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rating Must be between around 0 and 5")]
        public decimal Rating { get; set; }
        [Required]
        public string? Reviews { get; set; }

        // navigation properties
        public Guid UserId { get; set; }
        public Guid Bookid { get; set; }

        /*public User? User { get; set; }
        public Book? Book { get; set; }*/

        // Db Operation
        public static Review GetbyUserandBook(Guid userId, Guid bookId, BookifyDbContext bookifyDbContext)
        {
            var review = bookifyDbContext.Reviews.FirstOrDefault(r => (r.UserId == userId && r.Bookid == bookId));

            if (review == null)
                return null;

            return review;
        }
        public async Task Save(BookifyDbContext bookifyDbContext)
        {
            Id = Guid.NewGuid();

            await bookifyDbContext.Reviews.AddAsync(this);
            await bookifyDbContext.SaveChangesAsync();
        }
    }
}

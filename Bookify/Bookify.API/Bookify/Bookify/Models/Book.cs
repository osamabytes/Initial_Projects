using Bookify.Data;
using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "Please Enter a Valid ISBN")]
        public string? ISBN { get; set; }
        [Required]
        public string? Pic1 { get; set; }
        public string? Pic2 { get; set; }

        // navigation properties
        /*
           public List<Book_Category>? Book_Categories { get; set; }
           public Book_Bookshop? Book_Bookshop { get; set; }
           public List<Review>? reviews { get; set; }
        */

        // Db Operations
        public static Book GetbyISBN(string? ISBN, BookifyDbContext bookifyDbContext)
        {
            var book = bookifyDbContext.Books.FirstOrDefault(b => b.ISBN == ISBN);

            if (book == null)
                return null;

            return book;
        }
        public async Task Save(BookifyDbContext bookifyDbContext)
        {
            Id = Guid.NewGuid();

            await bookifyDbContext.Books.AddAsync(this);
            await bookifyDbContext.SaveChangesAsync();
        }
    }
}

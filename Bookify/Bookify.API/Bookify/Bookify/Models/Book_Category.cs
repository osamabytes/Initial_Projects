using Bookify.Data;

namespace Bookify.Models
{
    public class Book_Category
    {
        public Guid Id { get; set; }
        
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        // DB Operations
        public async Task Save(BookifyDbContext bookifyDbContext)
        {
            Id = Guid.NewGuid();

            await bookifyDbContext.Book_Categories.AddAsync(this);
            await bookifyDbContext.SaveChangesAsync();
        }
    }
}

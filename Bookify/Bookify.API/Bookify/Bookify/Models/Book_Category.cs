namespace Bookify.Models
{
    public class Book_Category
    {
        public Guid Id { get; set; }
        
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }
    }
}

namespace Bookify.Models
{
    public class Book_Bookshop
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public Guid BookshopId { get; set; }
        public Bookshop? BookShop { get; set; }
    }
}

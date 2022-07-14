namespace Bookify.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public string? Pic1 { get; set; }
        public string? Pic2 { get; set; }
        public string? CreatedAt { get; set; }

        // navigation properties
        public List<Book_Category>? Book_Categories { get; set; }

        public Guid ReviewId { get; set; }
        public Review? Review { get; set; }

        public Guid BookshopId { get; set; }
        public Bookshop? BookShop { get; set; }
    }
}

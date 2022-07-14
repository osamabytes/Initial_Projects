namespace Bookify.Models
{
    public class Bookshop
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedAt { get; set; }

        // navigation properties
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public List<Book_Bookshop>? Book_Bookshops { get; set; }
    }
}

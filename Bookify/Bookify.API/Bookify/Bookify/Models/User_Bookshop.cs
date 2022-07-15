namespace Bookify.Models
{
    public class User_Bookshop
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid BookshopId { get; set; }
        public Bookshop? Bookshop { get; set; }

    }
}

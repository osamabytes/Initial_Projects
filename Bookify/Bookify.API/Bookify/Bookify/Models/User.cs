namespace Bookify.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? CreatedAt { get; set; }

        // navigation properties
        public Guid TypeId { get; set; }
        public Type? Type { get; set; }

        public Guid BookshopId { get; set; }
        public Bookshop? Bookshop { get; set; }

        public List<User_Review>? User_Reviews { get; set; }

    }
}

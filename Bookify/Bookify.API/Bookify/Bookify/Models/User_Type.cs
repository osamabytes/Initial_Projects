namespace Bookify.Models
{
    public class User_Type
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid? TypeId { get; set; }
        public Type? Type { get; set; }

    }
}

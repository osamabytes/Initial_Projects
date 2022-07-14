namespace Bookify.Models
{
    public class User_Review
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid ReviewId { get; set; }
        public Review? Review { get; set; }
    }
}

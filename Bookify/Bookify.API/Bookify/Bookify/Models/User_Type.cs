namespace Bookify.Models
{
    public class User_Type
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public Guid UserTypeId { get; set; }
        public Type? UserType { get; set; }
    }
}

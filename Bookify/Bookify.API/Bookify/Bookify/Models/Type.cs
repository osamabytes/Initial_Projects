namespace Bookify.Models
{
    public class Type
    {
        public Guid id { get; set; }
        public string? Name { get; set; }
        public string? CreatedAt { get; set; }

        public List<User_Type>? User_Types { get; set; }

    }
}

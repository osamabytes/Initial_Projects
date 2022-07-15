using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Type
    {
        public Guid id { get; set; }
        public string? Name { get; set; }
        [Timestamp]
        public byte[]? CreatedAt { get; set; }

        // navigation properties
        public List<User_Type>? User_Types { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Type
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }

        // navigation properties
        /*public List<User_Type>? User_Types { get; set; }*/

    }
}

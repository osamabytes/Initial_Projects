using Bookify.Data;
using Microsoft.EntityFrameworkCore;
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

        // Db Functions
        public static Type GetById(Guid? id, BookifyDbContext bookifyDbContext)
        {
            var type = bookifyDbContext.Types.FirstOrDefault(t => t.Id == id);

            if (type == null)
                return null;

            return type;
        }
    }
}

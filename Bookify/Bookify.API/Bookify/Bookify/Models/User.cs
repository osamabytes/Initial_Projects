using Bookify.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class User: IdentityUser<Guid>
    {
        [Key]
        public override Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // navigation properties
        /*public User_Type? User_Type { get; set; }

        public User_Bookshop? User_Bookshop { get; set; }

        public List<Review>? reviews { get; set; }*/

        // Db Operations
        public static List<User> All(Guid SuperUid, BookifyDbContext bookifyDbContext)
        {
            var users = bookifyDbContext.Users.ToList();
            // exclude the super user
            users.RemoveAll(u => u.Id == SuperUid);
            return users;
        }

    }
}

using Bookify.Data;
using System.ComponentModel.DataAnnotations;

namespace Bookify.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }

        // navigation properties
        /*public List<Book_Category>? Book_Categories { get; set; }*/

        // Db Operations
        public static List<Category> GetAllCategories(BookifyDbContext bookifyDbContext)
        {
            var categories = bookifyDbContext.Categories.ToList();
            return categories;
        }
        public async Task Save(BookifyDbContext bookifyDbContext)
        {
            Id = Guid.NewGuid();

            await bookifyDbContext.Categories.AddAsync(this);
            await bookifyDbContext.SaveChangesAsync();
        }
    }
}

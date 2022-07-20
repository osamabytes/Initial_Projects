using Bookify.Data;

namespace Bookify.Models
{
    public class User_Bookshop
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid BookshopId { get; set; }
        public Bookshop? Bookshop { get; set; }

        // Db Operations
        public async Task Save(BookifyDbContext bookifyDbContext)
        {
            Id = Guid.NewGuid();

            await bookifyDbContext.User_Bookshops.AddAsync(this);
            await bookifyDbContext.SaveChangesAsync();
        }
    }
}

using Bookify.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Data
{
    public class BookifyDbContext: DbContext
    {
        public BookifyDbContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Type>()
                .HasOne(t => t.Type)
                .WithMany(u => u.User_Types)
                .HasForeignKey(u => u.TypeId);
        }
    }
}

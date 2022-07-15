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
            modelBuilder.Entity<User>()
                .HasOne<User_Type>(u => u.User_Type)
                .WithOne(ut => ut.User)
                .HasForeignKey<User_Type>(ut => ut.UserId);

            modelBuilder.Entity<User_Type>()
                .HasOne<User>(u => u.User)
                .WithOne(u => u.User_Type)
                .HasForeignKey<User_Type>(ut => ut.UserId);

            modelBuilder.Entity<Models.Type>()
                .HasMany(t => t.User_Types)
                .WithOne(ut => ut.Type)
                .HasForeignKey(ut => ut.TypeId);

            modelBuilder.Entity<Book>()
                .HasOne<Book_Bookshop>(b => b.Book_Bookshop)
                .WithOne(bb => bb.Book)
                .HasForeignKey<Book_Bookshop>(bb => bb.BookId);

            modelBuilder.Entity<Book_Bookshop>()
                .HasOne<Book>(b => b.Book)
                .WithOne(b => b.Book_Bookshop)
                .HasForeignKey<Book_Bookshop>(bb => bb.BookId);

            modelBuilder.Entity<Bookshop>()
                .HasMany(b => b.Book_Bookshops)
                .WithOne(bb => bb.BookShop)
                .HasForeignKey(bb => bb.BookshopId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Book>()
                .HasMany(u => u.reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.Bookid);

            modelBuilder.Entity<User>()
                .HasOne<User_Bookshop>(u => u.User_Bookshop)
                .WithOne(ub => ub.User)
                .HasForeignKey<User_Bookshop>(ub => ub.UserId);

            modelBuilder.Entity<User_Bookshop>()
                .HasOne<User>(u => u.User)
                .WithOne(u => u.User_Bookshop)
                .HasForeignKey<User_Bookshop>(ub => ub.UserId);

            modelBuilder.Entity<Bookshop>()
                .HasOne<User_Bookshop>(u => u.User_Bookshop)
                .WithOne(ub => ub.Bookshop)
                .HasForeignKey<User_Bookshop>(ub => ub.BookshopId);

            modelBuilder.Entity<User_Bookshop>()
                .HasOne<Bookshop>(u => u.Bookshop)
                .WithOne(u => u.User_Bookshop)
                .HasForeignKey<User_Bookshop>(ub => ub.BookshopId);

            modelBuilder.Entity<Book_Category>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.Book_Categories)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Book_Category>()
                .HasOne(c => c.Category)
                .WithMany(bc => bc.Book_Categories)
                .HasForeignKey(c => c.CategoryId);

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Bookshop> Bookshops { get; set; }

        public DbSet<Book_Bookshop> Book_Bookshops { get; set; }
        public DbSet<Book_Category> Book_Categories { get; set; }
        public DbSet<User_Type> User_Types { get; set; }
        public DbSet<User_Bookshop> User_Bookshops { get; set; }
    }
}

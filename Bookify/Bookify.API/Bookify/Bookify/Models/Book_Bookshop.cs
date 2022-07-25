using Bookify.Data;

namespace Bookify.Models
{
    public class Book_Bookshop
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public Guid BookshopId { get; set; }
        public Bookshop? BookShop { get; set; }

        // Db Operations
        public static List<Book_Bookshop> GetBookbyBookShop(Guid BookShopUid, BookifyDbContext bookifyDbContext)
        {
            var book_bs = bookifyDbContext.Book_Bookshops.Where<Book_Bookshop>(bbs => bbs.BookshopId == BookShopUid);

            var bbs = book_bs.ToList();
            foreach(var bb in bbs)
            {
                if(bb.Book == null)
                {
                    bb.Book = Book.GetById(bb.BookId, bookifyDbContext);
                }
            }

            return bbs;
        }
        public async Task Save(BookifyDbContext bookifyDbContext)
        {
            Id = Guid.NewGuid();

            await bookifyDbContext.Book_Bookshops.AddAsync(this);
            await bookifyDbContext.SaveChangesAsync();
        }
    }
}

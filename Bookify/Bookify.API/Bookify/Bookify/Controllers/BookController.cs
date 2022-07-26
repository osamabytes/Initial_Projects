using Bookify.Constants;
using Bookify.Data;
using Bookify.Dto;
using Bookify.Helper;
using Bookify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly BookifyDbContext _bookifyDbContext;

        public BookController(UserManager<User> userManager, BookifyDbContext bookifyDbContext)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var useremail = User.Claims.FirstOrDefault();
            if (useremail == null)
                return NotFound();

            var user = await _userManager.FindByEmailAsync(useremail.Value);

            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _bookifyDbContext);

            if(ut.TypeId == AppConfig.CustomerGuid || ut.TypeId == AppConfig.SuperAdminGuid)
            {
                List<Book> books = Book.GetAllBooks(_bookifyDbContext);
                return Ok(books);
            }
            else
            {
                User_Bookshop? ubs = User_Bookshop.GetByUserId(user.Id, _bookifyDbContext);
                List<Book_Bookshop> bbs = Book_Bookshop.GetBookbyBookShop(ubs.BookshopId, _bookifyDbContext);

                List<Book> books = new List<Book>();
                foreach(var bb in bbs)
                {
                    books.Add(bb.Book);
                }

                return Ok(books);
            }

            return Unauthorized(new GeneralAuthResponseDto
            {
                IsAllowed = true,
                Errors = new List<string> { "User not allowed for this feature" }
            });
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> AddBook()
        {

            var useremail = User.Claims.FirstOrDefault();
            if (useremail == null)
                return NotFound();

            var user = await _userManager.FindByEmailAsync(useremail.Value);

            
            User_Type ut = User_Type.GetUserTypeByUserId(user.Id, _bookifyDbContext);

            if(ut.TypeId == AppConfig.AdminGuid)
            {
                var formCollection = await Request.ReadFormAsync();
                var bks = formCollection["Book"];
                var cs = formCollection["Categories"];
                var image1 = formCollection.Files["Image1"];
                var image2 = formCollection.Files["Image2"];

                BookCategoriesDto bookCategoriesDto = new BookCategoriesDto();

                // desearlize the jsoncontent
                bookCategoriesDto.Book = JsonHelper.DesearlizeBook(bks);
                bookCategoriesDto.Categories = JsonHelper.DesearlizeCategories(cs);
                bookCategoriesDto.Image1 = image1;
                bookCategoriesDto.Image2 = image2;

                var book = bookCategoriesDto.Book;
                var categories = bookCategoriesDto.Categories;

                // Get UserBookShop
                User_Bookshop ub = User_Bookshop.GetByUserId(user.Id, _bookifyDbContext);

                // Add Book
                Book b = new Book();
                if (Book.GetbyISBN(book?.ISBN, _bookifyDbContext) != null)
                    return BadRequest(new GeneralAuthResponseDto { IsAllowed = false, Errors = new List<string> { "Book Already Exists in the System" } });

                b.Name = book.Name;
                b.Description = book.Description;
                b.ISBN = book.ISBN;
                b.Pic1 = book.Pic1;
                b.Pic2 = book.Pic2;

                // Save Book
                await b.Save(_bookifyDbContext);

                // Save book category
                foreach(var category in categories)
                {
                    Book_Category bc = new Book_Category();
                    bc.BookId = b.Id;
                    bc.CategoryId = category.Id;

                    await bc.Save(_bookifyDbContext);
                }

                // Save Book Bookshop
                Book_Bookshop bbs = new Book_Bookshop();
                bbs.BookId = b.Id;
                bbs.BookshopId = ub.BookshopId;

                await bbs.Save(_bookifyDbContext);

                // Copy the uploaded images to the folder
                if(image1 != null)
                    SaveImage.Save(bookCategoriesDto.Image1);

                if (image2 != null)
                    SaveImage.Save(bookCategoriesDto.Image2);

                return Ok(b);
            }

            return Unauthorized(new GeneralAuthResponseDto { 
                IsAllowed = true,
                Errors = new List<string> { "User not allowed for this feature" }
            });
        }
    }
}

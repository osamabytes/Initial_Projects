using Bookify.Data;
using Bookify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookifyDbContext _bookifyDbContext;

        public BookController(BookifyDbContext bookifyDbContext)
        {
            _bookifyDbContext = bookifyDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            book.Id = Guid.NewGuid();

            await _bookifyDbContext.Books.AddAsync(book);
            await _bookifyDbContext.SaveChangesAsync();

            return Ok(book);
        }
    }
}

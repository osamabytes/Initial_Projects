using Bookify.Models;

namespace Bookify.Dto
{
    public class BookCategoriesDto
    {
        public Book? Book { get; set; }
        public List<Category>? Categories { get; set; }
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
    }
}

using Bookify.Models;

namespace Bookify.Dto
{
    public class BookCategoriesDto
    {
        public Book? Book { get; set; }
        public List<Category>? Categories { get; set; }

    }
}

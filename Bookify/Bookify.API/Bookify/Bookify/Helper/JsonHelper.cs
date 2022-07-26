using Bookify.Models;
using System.Text.Json;

namespace Bookify.Helper
{
    public class JsonHelper
    {
        public static Book DesearlizeBook(string data)
        {
            var book = JsonSerializer.Deserialize<Book>(data);
            return book;
        }

        public static List<Category> DesearlizeCategories(string data)
        {
            var categories = JsonSerializer.Deserialize<List<Category>>(data);
            return categories;
        }
    }
}

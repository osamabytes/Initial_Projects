using Bookify.Models;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Bookify.Helper
{
    public class JsonHelper
    {
        public static Book DesearlizeBook(string data)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                DataContractJsonSerializer? dataContractJsonSerializer = new DataContractJsonSerializer(typeof(Book));
                return (Book?)dataContractJsonSerializer.ReadObject(stream);
            }
        }

        public static List<Category> DesearlizeCategories(string data)
        {
            var categories = JsonSerializer.Deserialize<List<Category>>(data);
            return categories;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libros_LINQ
{
    public class LinqQueries
    {
        private List<Book> bookCollection = new List<Book>();
        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.bookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }
        public IEnumerable<Book> AllCollection()
        {
            return bookCollection;
        }

        public IEnumerable<Book> BooksAfter2000()
        {
            return bookCollection.Where(p => p.PublishedDate.Year > 2000);
        }
    }
}

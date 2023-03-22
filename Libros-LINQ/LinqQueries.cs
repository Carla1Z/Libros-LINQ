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
            //extension method
            //return bookCollection.Where(p => p.PublishedDate.Year > 2000);

            //query expresion
            return from b in bookCollection where b.PublishedDate.Year > 2000 select b;
        }

        public IEnumerable<Book> Book250PagesInAction()
        {
            //extension method
            //return bookCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            //query expresion
            return from b in bookCollection where b.PageCount > 250 && b.Title.Contains("in Action") select b;
        }

        public bool AllBooksStatus()
        {
            return bookCollection.All(p => p.Status != string.Empty);
        }

        public bool BookPublished2005()
        {
            return bookCollection.Any(p => p.PublishedDate.Year == 2005);
        }
    }
}

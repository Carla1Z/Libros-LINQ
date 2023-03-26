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

        public IEnumerable<Book> PythonBook()
        {
            return bookCollection.Where(p => p.Categories.Contains("Python"));
        }

        public IEnumerable<Book> JavaBooksAsc()
        {
            return bookCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
        }

        public IEnumerable<Book> Book450PagesDesc()
        {
            return bookCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
        }

        public IEnumerable<Book> FirstThreeJavaBooksDate()
        {
            return bookCollection
                .Where(p => p.Categories.Contains("Java"))
                .OrderByDescending(p => p.PublishedDate)
                .Take(3);
        }

        public IEnumerable<Book> ThirdFourthBook400Pages()
        {
            return bookCollection
                .Where(p => p.PageCount > 400)
                .Take(4)
                .Skip(2);
        }

    }
}

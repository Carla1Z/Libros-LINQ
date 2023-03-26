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

        public IEnumerable<Book> FirstThreeBooks()
        {
            return bookCollection.Take(3)
               .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
        }

        public long NumberBooksBetween200and500Pages()
        {
            return bookCollection
                .LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
        }

        public DateTime MinorDate()
        {
            return bookCollection.Min(p => p.PublishedDate);
        }

        public int PagesBiggestBook()
        {
            return bookCollection.Max(p => p.PageCount);
        }

        public Book BookFewerPages()
        {
            return bookCollection
                .Where(p => p.PageCount > 0)
                .MinBy(p => p.PageCount);
        }

        public Book MostRecentBook()
        {
            return bookCollection.MaxBy(p => p.PublishedDate);
        }

        public int SumOfPages()
        {
            return bookCollection
                .Where(p => p.PageCount >= 0 && p.PageCount <= 500)
                .Sum(p => p.PageCount);
        }

        public string BooksAfter2015()
        {
            return bookCollection
                .Where(p => p.PublishedDate.Year > 2015)
                .Aggregate("", (BooksTitles, next) =>
                {
                    if (BooksTitles != string.Empty)
                        BooksTitles += " - " + next.Title;
                    else
                        BooksTitles += next.Title;

                    return BooksTitles;
                }
                );
        }

        public double CharacterAverage()
        {
            return bookCollection.Average(p => p.Title.Length);
        }
    }
}

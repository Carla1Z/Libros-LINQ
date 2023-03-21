using Libros_LINQ;

LinqQueries queries = new LinqQueries();

PrintValues(queries.AllCollection());

void PrintValues(IEnumerable<Book> listBooks)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha publicación");
    foreach (var item in listBooks)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
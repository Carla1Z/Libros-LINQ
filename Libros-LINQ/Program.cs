using Libros_LINQ;

LinqQueries queries = new LinqQueries();

//Toda la colección
//PrintValues(queries.AllCollection());

//Libros despues del 2000
//PrintValues(queries.BooksAfter2000());

//Libros que tienen mas de 250 páginas, y tienen en el título la palabra 'in action'
//PrintValues(queries.Book250PagesInAction());

//Todos los libros tiene Status
//Console.WriteLine($"¿Todos los libros tienen status? - {queries.AllBooksStatus()}");

//Si algun libro fue publicado en 2005
//Console.WriteLine($"¿Algun libro fue publicado en 2005? - {queries.BookPublished2005()}");

//Libros de Python
//PrintValues(queries.PythonBook());

//Libros de Java ordenados por nombre
PrintValues(queries.JavaBooksAsc());

void PrintValues(IEnumerable<Book> listBooks)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha publicación");
    foreach (var item in listBooks)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
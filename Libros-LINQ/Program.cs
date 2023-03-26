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
//PrintValues(queries.JavaBooksAsc());

//Libros que tienen mas de 450 paginas ordenados por cantidad de paginas
//PrintValues(queries.Book450PagesDesc());

//Loa tres libros de Java publicados recientemente
//PrintValues(queries.FirstThreeJavaBooksDate());

//Tercer y cuarto libro de mas de 400 paginas
//PrintValues(queries.ThirdFourthBook400Pages());

//Tres primeros libros filtrados con select
//PrintValues(queries.FirstThreeBooks());

//Cantidad delibros que tienen entre 200 y 500 paginas
//Console.WriteLine($"Cantidad delibros que tienen entre 200 y 500 páginas: {queries.NumberBooksBetween200and500Pages()}");

//Libro con fecha de publicacion mas antigua de toda la coleccion
//Console.WriteLine($"Libro mas antiguo: {queries.MinorDate()}");

//Número de páginas del libro con mayor número de páginas
//Console.WriteLine($"El libro con mayor número de páginas tiene {queries.PagesBiggestBook()} páginas.");

//Libro con menor número de páginas 
var minorPages = queries.BookFewerPages();
//Console.WriteLine($"{minorPages.Title} - {minorPages.PageCount}");

//Libro con fecha de publicación mmás reciente
var recentBook = queries.MostRecentBook();
//Console.WriteLine($"{recentBook.Title} - {recentBook.PublishedDate.ToShortDateString()}");

//Suma de página de libros entre 0 y 500
//Console.WriteLine($"Suma total de páginas: {queries.SumOfPages()}");

//Libros publicados despues del 2015
//Console.WriteLine(queries.BooksAfter2015());

//El promedio de caracteres del título de los libros
Console.WriteLine($"Promedio de los caracteres de los títulos: {queries.CharacterAverage()}");


void PrintValues(IEnumerable<Book> listBooks)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Páginas", "Fecha publicación");
    foreach (var item in listBooks)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
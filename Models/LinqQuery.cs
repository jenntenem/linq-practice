using System.Text.Json;

class LinqQuery
{
  private readonly List<Book> _booksCollection;
  private const string FILE_PATH = "data/books.json";

  public LinqQuery()
  {
    _booksCollection = new List<Book>();
    /*
    Using Newtonsoft.Json - the most popular JSON library
    string json = JsonConvert.SerializeObject(student);
    var obj = JsonConvert.DeserializeObject<Student>(json);

    Using System.Text.Json - It’s fast and doesn’t use much computer memory.
    string json = JsonSerializer.Serialize(student);
    var obj = JsonSerializer.Deserialize<Student>(json);

    Using NetJSON - It’s faster than both 
    string json = NetJSON.Serialize(student);
    var  obj = NetJSON.Deserialize<Student>(json);
    */

    if (File.Exists(FILE_PATH))
    {
      using (StreamReader reader = new StreamReader(FILE_PATH))
      {
        string dataJson = reader.ReadToEnd();
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        List<Book>? books = JsonSerializer.Deserialize<List<Book>>(dataJson, options); // El json es string, Deserializarlo a JSON
        if (books != null && books.Any())
          this._booksCollection = books;

        /*
        NON-NULLEABLE
        JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!
        NULLEABLE
        JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
  X      */
      }
    }

  }

  // Obtiene todos los libros
  public IEnumerable<Book> getAllBooks() => this._booksCollection;

  // Imprime una coleccion de libros
  public void printValues(IEnumerable<Book>? books = null)
  {
    if (books == null)
      books = new List<Book>();

    Console.WriteLine("{0,-60} {1, 15} {2, 15}", "Titulo", "N. Paginas", "Fecha de publicacion");
    books.ToList().ForEach(book => Console.WriteLine("{0,-60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString()));
    // foreach (var book in books)
    // {
    //   Console.WriteLine("{0,-60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    // }
  }

  // Imprime una coleccion de libros agrupados
  public void printValuesGrouping(IEnumerable<IGrouping<int, Book>> books)
  {
    Console.WriteLine("{0,-60} {1, 15} {2, 15}", "Titulo", "N. Paginas", "Fecha de publicacion");
    books.ToList().ForEach(g =>
    {
      Console.WriteLine($"Group {g.Key}:");
      g.ToList().ForEach(b => Console.WriteLine("{0,-60} {1, 15} {2, 15}", b.Title, b.PageCount, b.PublishedDate.ToShortDateString()));
    });
  }

    // Imprime un diccionario
  public void printValuesDictionary(ILookup<char, Book> books, char letter)
  {
    Console.WriteLine("{0,-60} {1, 15} {2, 15}", "Titulo", "N. Paginas", "Fecha de publicacion");
    foreach(var b in books[letter]) {
      Console.WriteLine("{0,-60} {1, 15} {2, 15}", b.Title, b.PageCount, b.PublishedDate.ToShortDateString());
    }
  }
}
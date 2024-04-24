using System.Text.Json;

class LinqQuery
{
  public List<Book> booksCollection = new List<Book>();

  public LinqQuery()
  {
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

    using (StreamReader reader = new StreamReader("data/books.json"))
    {
      string dataJson = reader.ReadToEnd();
      this.booksCollection = JsonSerializer.Deserialize<List<Book>>(dataJson,
      new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); // El json es string, Deserializarlo a JSON
      // this.booksCollection.ForEach(b => Console.WriteLine(b.Title));

      /*
      NON-NULLEABLE
      JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!
      NULLEABLE
      JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();
X      */
    }
  }

  public IEnumerable<Book> AllCollection()
  {
    return booksCollection;
  }
}
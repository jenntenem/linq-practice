class LinqQuery {
  public List<Book> booksCollection = new List<Book>();

  public LinqQuery() {
    using(StreamReader reader = new StreamReader("data/books.json"))
        {
          string dataJson = reader.ReadToEnd();
          // El texto viene como string, Deserializarlo a JSON
          this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(dataJson, 
          new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
  }

  public IEnumerable<Book> AllCollection()
    {
        return booksCollection;
    }
}
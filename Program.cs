var linqData = new LinqQuery();
var books = linqData.getAllBooks();

// *Get All Books
// linqData.printValues(books);

// * Book before 2000
// extension method
// linqData.printValues(
//   books.Where(book => book.PublishedDate.Year > 2000));

// query expresion
// linqData.printValues(
//   from b in books
//   where b.PublishedDate.Year > 2000
//   select b
// );

// * Books < 250pages and title have 'Action'
// linqData.printValues(
//   books.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"))
// );

// linqData.printValues(
//   from b in books
//   where b.PageCount > 250 && b.Title.Contains("in Action")
//   select b
// );

// * All - ANY
// bool _allBooksHaveStatus = books.All(b => b.Status != string.Empty || b.Status != null);
bool _allBooksHaveStatus = books.All(b => !string.IsNullOrWhiteSpace(b.Status));
bool _anyBooksHaveStatus = books.Any(b => b.Status == string.Empty || b.Status == null);

Console.WriteLine($"Todos los libros tienen status: {_allBooksHaveStatus}");
Console.WriteLine($"Existe un libro que no tenga status: {_anyBooksHaveStatus}");

// Any Book published in 2005
bool _anyBook2005 = books.Any(b => b.PublishedDate.Year == 2005);
Console.WriteLine($"Existe un libro publicado en 2005: {_anyBook2005}");

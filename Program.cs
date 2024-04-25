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
// // bool _allBooksHaveStatus = books.All(b => b.Status != string.Empty || b.Status != null);
// bool _allBooksHaveStatus = books.All(b => !string.IsNullOrWhiteSpace(b.Status));
// bool _anyBooksHaveStatus = books.Any(b => b.Status == string.Empty || b.Status == null);

// Console.WriteLine($"Todos los libros tienen status: {_allBooksHaveStatus}");
// Console.WriteLine($"Existe un libro que no tenga status: {_anyBooksHaveStatus}");

// // Any Book published in 2005
// bool _anyBook2005 = books.Any(b => b.PublishedDate.Year == 2005);
// Console.WriteLine($"Existe un libro publicado en 2005: {_anyBook2005}");

// * CONTAINS
// linqData.printValues(books.Where(b => b.Title.Contains("Python"))); // string -> ike
// linqData.printValues(books.Where(b => b.Categories.Contains("Python"))); // string[] -> include/where

// * ORDER BY - ORDER BY DESCENDING
// var javaBooks = books.Where(b => b.Categories.Contains("Java"));
// linqData.printValues(javaBooks.OrderBy(b => b.Title)); // Order by ASC Title (string)
// linqData.printValues(javaBooks.OrderByDescending(b => b.PageCount)); // Order by DESC PageCount (int)

// // Order by -> DESC PageCount (int) -> ASC Title (string)
// linqData.printValues(javaBooks.OrderByDescending(b => b.PageCount).ThenBy(b => b.Title)); 
// linqData.printValues(
//   from jb in javaBooks
//   orderby jb.PageCount descending, jb.PageCount ascending
//   select jb
// );

// * TAKE
// linqData.printValues(
//   books
//   .Where(b => b.Categories.Contains("Java"))
//   .OrderByDescending(b => b.PageCount)
//   .Take(3)
// );

// linqData.printValues(
//   books
//   .Where(b => b.Categories.Contains("Java"))
//   .OrderByDescending(b => b.PageCount)
//   .TakeLast(3)
// );

// linqData.printValues(
//   books
//   .Where(b => b.Categories.Contains("Java"))
//   .OrderByDescending(b => b.PageCount)
//   .TakeWhile(b => b.PageCount >= 550)
//   );

// linqData.printValues(
//   from b in books
//   where b.Categories.Contains("Java") && b.PageCount >= 550
//   orderby b.PageCount descending
//   select b
// );

// * SKIP
// linqData.printValues(
//   books
//   .Where(b => b.Categories.Contains("Java"))
//   .OrderByDescending(b => b.PageCount)
//   .Take(4)
//   .Skip(2) // omite los 2 primeros registros
// );

// SELECT 
linqData.printValues(
  books
  .Where(b => b.PageCount > 400)
  .Select(b => new Book { Title = b.Title, PageCount = b.PageCount })
);

// AGGREGATION FUNCTIONS
// * COUNT - LONGCOUNT
// Console.WriteLine($"Total libros: {books.Count()}");
// Console.WriteLine($"Total libros: {books.LongCount()}");
// Console.WriteLine($"Libros con más de 400 pags.: {books.LongCount(b => b.PageCount > 400)}");

// * MAX - MIN (RETURN VALUE)
// Console.WriteLine($"Menor fecha de publicación: {books.Min(b => b.PublishedDate)}");
// Console.WriteLine($"Mayor fecha de publicación: {books.Max(b => b.PublishedDate)}");

// MAX BY - MIN BY (RETURN OBJECT)
// Console.WriteLine($"Menor fecha de publicación: {books.MinBy(b => b.PublishedDate).ToString()}");
// Console.WriteLine($"Mayor fecha de publicación: {books.MaxBy(b => b.PublishedDate).ToString()}");

// SUM - AGGREGATE LIKE REDUCE
// Console.WriteLine($"Cantidad de hojas en libros publicados desde el 2000: {books
//   .Where(b => b.PublishedDate.Year > 2000)
//   .Sum(b => b.PageCount)}");

// Console.WriteLine($"Título de libros después del 2015: {books
//   .Where(b => b.PublishedDate.Year > 2015)
//   .Aggregate("", (acc, val) => acc == string.Empty ? acc = val.Title : acc += " - " + val.Title)}");

// AVERAGE
// Console.WriteLine($"Promedio de caracteres que tienen los titulos de los libros: {books.Average(b => b.Title.Length)}");

// * AGRUPAMIENTO DE DATOS
// * GROUP BY
// Books published since 2000, grouped by year
// var groupedBooks = books.Where(b => b.PublishedDate.Year > 2000)
//                         .GroupBy(b => b.PublishedDate.Year); // IEnumerable<IGrouping<int, Book>>
// linqData.printValuesGrouping(groupedBooks);

// * lOOK UP -> dictionary
// dictionary from books by first letter
var bookDictionary = books.ToLookup(b => b.Title[0], p => p); // Lookup<char, Book>
linqData.printValuesDictionary(bookDictionary, 'P');
var linqData = new LinqQuery();
var books = linqData.AllCollection();

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
linqData.printValues(
  books.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"))
);

linqData.printValues(
  from b in books
  where b.PageCount > 250 && b.Title.Contains("in Action")
  select b
);
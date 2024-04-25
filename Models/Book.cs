class Book
{
  public string Title { get; set; }
  public int PageCount { get; set; }
  public DateTime PublishedDate { get; set; }
  public string Status { get; set; }
  public string[] Authors { get; set; }
  public string[] Categories { get; set; }

  public override string ToString() => $"{Title}, {PageCount} pages, {PublishedDate.ToShortDateString()} published date";
}
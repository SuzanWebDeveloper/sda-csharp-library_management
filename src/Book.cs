
namespace LibraryManagement;

public class Book : LibraryItem
{
  public string? type;
  public Book(string title, DateTime createdDate = default) : base(title, createdDate)
  { }

  // override ToString method to display an object
  public override string ToString()
  {
    return $"Book Id: {Id}, Title:  {Title}, Created Date: {CreatedDate}";
  }
}
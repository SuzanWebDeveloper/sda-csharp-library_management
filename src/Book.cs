namespace LibraryManagement;
public class Book
{
  public Guid Id { get; }
  public string? Title { set; get; }
  public DateTime CreatedDate { set; get; }
  public string? type;

  public Book(string title, DateTime createdDate = default)
  {
    Id = Guid.NewGuid();
    Title = title;
    CreatedDate = createdDate == default ? DateTime.Now : createdDate;
  }
  // override ToString method to display an object
  public override string ToString()
  {
    return $"Book Id: {Id}, Title:  {Title}, Created Date: {CreatedDate}";
  }
}
namespace LibraryManagement;

public class LibraryItem
{
  public Guid Id { get; }
  public string? Title { set; get; }
  public DateTime CreatedDate { set; get; }
  public LibraryItem(string title, DateTime createdDate = default)
  {
    Id = Guid.NewGuid();
    Title = title;
    CreatedDate = createdDate == default ? DateTime.Now : createdDate;
  }
}
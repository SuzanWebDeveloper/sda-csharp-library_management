namespace LibraryManagement;
public class Book
{
  private int _id;
  private string? _title;
  private DateTime _createdDate;
  public string? type;
  public int Id { set; get; }
  public string? Title{ set; get;}
  public DateTime CreatedDate {set; get;}
}
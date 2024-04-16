namespace LibraryManagement;

public class User : LibraryItem
{
  public string? Name { set; get; }
  public User(string name, DateTime createdDate = default) : base(name, createdDate)
  {
    Name = name;
  }

  // override ToString method to display an object
  public override string ToString()
  {
    return $"User Id: {Id}, Name:  {Name}, Created Date: {CreatedDate}";
  }
}
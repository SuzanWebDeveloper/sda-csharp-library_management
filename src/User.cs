namespace LibraryManagement;

public class User
{
  public Guid Id { get; }
  public string? Name { set; get; }
  public DateTime CreatedDate { set; get; }
  public User(string name, DateTime createdDate = default)
  {
    Id = Guid.NewGuid();
    Name = name;
    CreatedDate = createdDate == default ? DateTime.Now : createdDate;
  }

  // override ToString method to display an object
  public override string ToString()
  {
    return $"User Id: {Id}, Name:  {Name}, Created Date: {CreatedDate}";
  }
}
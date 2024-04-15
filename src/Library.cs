using Microsoft.VisualBasic;

namespace LibraryManagement;
public class Library
{
  private List<Book> _books = new List<Book>();
  private List<User> _users = new List<User>();

  // - Get all books/users with pagination, sorted by created date.
  public string GetAllBooksOrUsers(int id)
  {
    return "";
  }

  // - Find books by title
  public Book? FindBookByTitle(string bookTitle)
  {
    try
    {
      if (string.IsNullOrEmpty(bookTitle))
        throw new ArgumentException("Book title is null or empty");

      else
      {
        Book? bookFound = _books.FirstOrDefault(book => string.Equals(book.Title, bookTitle, StringComparison.OrdinalIgnoreCase));

        if (bookFound != null)
        {
          Console.WriteLine($"Book title \"{bookTitle}\" is found\n");
          return bookFound;
        }
        else
        {
          Console.WriteLine($"Book title \"{bookTitle}\" is not found\n");
          return null;
        }
      }
    }
    catch (System.Exception e)
    {
      Console.WriteLine(e.Message);
      return null;
    }
  }

  // - Find users by name
  public User? FindUserByName(string userName)
  {
    try
    {
      if (string.IsNullOrEmpty(userName))
        throw new ArgumentException("User name is null or empty\n");

      else
      {
        User? userFound = _users.FirstOrDefault(user => string.Equals(user.Name, userName, StringComparison.OrdinalIgnoreCase));

        if (userFound != null)
        {
          Console.WriteLine($"User name \"{userName}\" is found\n");
          return userFound;
        }
        else
        {
          Console.WriteLine($"User name \"{userName}\" is not found\n");
          return null;
        }
      }
    }
    catch (System.Exception e)
    {
      Console.WriteLine(e.Message);
      return null;
    }


  }

  // - Add new book/user to the library
  public void AddBook(Book book)
  {
    try
    {
      if (book.Title == null)
        throw new ArgumentException("invalid book");

      //Do not allow to add items with same name to the library
      bool isExist = _books.Any(book => string.Equals(book.Title, book.Title, StringComparison.OrdinalIgnoreCase));

      if (isExist)
        throw new ArgumentException("book exists, can't be added");

      Console.WriteLine($"\nBook to be added: {book}");
      _books.Add(book);
      Console.WriteLine($"added book {book.Title} successfully\n");
    }
    catch (ArgumentOutOfRangeException e)
    {
      Console.WriteLine($"{e.Message}\n");
    }
    catch (ArgumentException e)
    {
      Console.WriteLine($"{e.Message}\n");
    }
  }
  public void AddUser(User user)
  {
    _users.Add(user);
    Console.WriteLine($"added user {user.Name} successfully\n");
  }

  //   public void AddBookOrUser<T>(T toBeAdded)
  //   {
  // if(toBeAdded is Book){
  //   try{
  //       if (toBeAdded.Title == null)
  //         throw new ArgumentException("invalid book");
  //       //Do not allow to add items with same name to the store
  //       bool isExist = _books.Any(book => string.Equals(book.Title, toBeAdded.Title, StringComparison.OrdinalIgnoreCase));
  //       if (isExist)
  //         throw new ArgumentException("book exists, can't be added");

  //       Console.WriteLine($"Book to be added: {toBeAdded}");
  //       _books.Add(toBeAdded);
  //       Console.WriteLine($"added {book.Title}\n");
  //     }

  //     catch (ArgumentOutOfRangeException e)
  //     {
  //       Console.WriteLine($"{e.Message}\n");
  //     }
  //     catch (ArgumentException e)
  //     {
  //       Console.WriteLine($"{e.Message}\n");
  //     }
  //   }
  //   }

  // - Delete book/user by id
  public void DeleteBook(Guid id)
  {
    Book? bookFound = _books.FirstOrDefault(book => string.Equals(book.Id.ToString(), id.ToString(), StringComparison.OrdinalIgnoreCase));
    if (bookFound != null)
    {
      _books.Remove(bookFound);
      Console.WriteLine($"book is deleted successfully\n");
    }
    else
    {
      Console.WriteLine($"Book Id \"{id}\" is not found\n");
    }
  }
  public void DeleteUser(Guid id)
  {
    User? userFound = _users.FirstOrDefault(user => string.Equals(user.Id.ToString(), id.ToString(), StringComparison.OrdinalIgnoreCase));
    if (userFound != null)
    {
      _users.Remove(userFound);
      Console.WriteLine($"user {userFound.Name} is deleted successfully\n");
    }
    else
    {
      Console.WriteLine($"User Id \"{id}\" is not found\n");
    }
  }
  // public void DeleteBookOrUser(int id)
  // {

  // }
}

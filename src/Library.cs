
namespace LibraryManagement;
using NotificationService;

public class Library
{
  private List<Book> _books;
  private List<User> _users;
  private INotificationService _notificationService;

  public Library(INotificationService notificationService)
  {
    _books = new List<Book>();
    _users = new List<User>();
    _notificationService = notificationService;
  }

  // - Get all books/users with pagination, sorted by created date.
  public void GetAllBooks()
  {
    var sortedBooks = _books.OrderBy(book => book.CreatedDate).ToList();
    int pageNumber = 1;
    int limit = 3;
    int itemsToSkip;

    int totalCount = _books.Count();
    Console.WriteLine($"Books TotalCount: {totalCount}");

    int totalPages = (int)Math.Ceiling(totalCount / (double)limit);
    Console.WriteLine($"TotalPages: {totalPages}");

    for (int i = 0; i < totalPages; i++)
    {
      Console.WriteLine($"Page: {pageNumber}");
      itemsToSkip = (pageNumber - 1) * limit;
      IEnumerable<Book> PagedBooks = _books.Skip(itemsToSkip).Take(limit);
      foreach (var book in PagedBooks)
      {
        Console.WriteLine($"{book.Id}, {book.Title}");
      }
      pageNumber++;
    }
  }

  public void GetAllUsers()
  {
    var sortedUsers = _users.OrderBy(user => user.CreatedDate).ToList();
    int pageNumber = 1;
    int limit = 3;
    int itemsToSkip;

    int totalCount = _users.Count();
    Console.WriteLine($"Users TotalCount: {totalCount}");

    int totalPages = (int)Math.Ceiling(totalCount / (double)limit);
    Console.WriteLine($"TotalPages: {totalPages}");

    for (int i = 0; i < totalPages; i++)
    {
      Console.WriteLine($"Page: {pageNumber}");
      itemsToSkip = (pageNumber - 1) * limit;
      IEnumerable<User> PagedBooks = _users.Skip(itemsToSkip).Take(limit);
      foreach (var user in PagedBooks)
      {
        Console.WriteLine($"{user.Id}, {user.Title}");
      }
      pageNumber++;
    }
  }

  // - Find books by title
  public List<Book>? FindBooksByTitle(string bookTitle)
  {
    try
    {
      if (string.IsNullOrEmpty(bookTitle))
        throw new ArgumentNullException("User name is null or empty\n");

      var bookFound = _books.FindAll(book => string.Equals(book.Title, bookTitle, StringComparison.OrdinalIgnoreCase)).ToList();

      if (bookFound.Count != 0 )
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
    catch (ArgumentNullException e)
    {
      Console.WriteLine(e.Message);
      return null;
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
      if (string.IsNullOrEmpty(book.Title))
        throw new ArgumentNullException();

      Book? bookFound = _books.FirstOrDefault(bookInList => string.Equals(bookInList.Id.ToString(), book.Id.ToString(), StringComparison.OrdinalIgnoreCase));

      if (bookFound != null)
        throw new ArgumentException();

      _books.Add(book);
      _notificationService.SendNotificationOnSuccess($"book titled \"{book.Title}\"", "added to");
    }
    catch (ArgumentNullException)
    {
      Console.WriteLine($"book title is null or empty\n");
    }
    catch (ArgumentException)
    {
      _notificationService.SendNotificationOnFailure($"book titled \"{book.Title}\"", "exists");
    }
  }

  public void AddUser(User user)
  {
    try
    {
      if (string.IsNullOrEmpty(user.Name))
        throw new ArgumentNullException();

      bool isExist = _users.Any(i => string.Equals(i.Name, user.Name, StringComparison.OrdinalIgnoreCase));

      if (isExist)
        throw new ArgumentException();

      _users.Add(user);
      _notificationService.SendNotificationOnSuccess($"user name \"{user.Name}\"", "added to");
    }
    catch (ArgumentNullException)
    {
      _notificationService.SendNotificationOnFailure($"user name", "null or empty");
    }
    catch (ArgumentException)
    {
      _notificationService.SendNotificationOnFailure($"user name \"{user.Name}\"", "exists");
    }
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
  //------------------------------

  // - Delete book/user by id

  public void DeleteBook(Guid id)
  {
    Book? bookFound = _books.FirstOrDefault(book => string.Equals(book.Id.ToString(), id.ToString(), StringComparison.OrdinalIgnoreCase));
    if (bookFound != null)
    {
      _books.Remove(bookFound);
      _notificationService.SendNotificationOnSuccess($"book titled \"{bookFound.Id}\"", "deleted from");
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
      _notificationService.SendNotificationOnSuccess($"user id \"{userFound.Id}\"", "deleted from");
    }
    else
    {
      Console.WriteLine($"user Id \"{id}\" is not found\n");
    }
  }

  // public Book? FindBookById(Guid id)
  // {
  //     Book? bookFound = _books.FirstOrDefault(book => string.Equals(book.Id.ToString(), id.ToString(), StringComparison.OrdinalIgnoreCase));
  //     return bookFound;
  //   }
}


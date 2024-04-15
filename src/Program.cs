namespace LibraryManagement;

internal class Program
{
    private static void Main()
    {
        var user1 = new User("Alice", new DateTime(2023, 1, 1));
        var user2 = new User("Bob", new DateTime(2023, 2, 1));
        var book1 = new Book("The Great Gatsby", new DateTime(2023, 1, 1));
        var library = new Library();

        library.AddBook(book1);
        library.AddBook(book1);
        library.AddUser(user1);
        library.AddUser(user2);

        Console.WriteLine($"user1 id: {user1}");
        Console.WriteLine($"user1 id: {user2}");
        Console.WriteLine($"{book1}");

        library.FindBookByTitle("The Great Gatsby");
        library.FindUserByName("Bob");

        library.DeleteBook(book1.Id);
        var result3 = library.FindBookByTitle("The Great Gatsby");
        Console.WriteLine($"{result3}");

        library.DeleteUser(user1.Id);
    }
}
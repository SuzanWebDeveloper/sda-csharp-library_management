namespace NotificationService;

public class EmailNotificationService : INotificationService
{
  public void SendNotificationOnSuccess(string identifier, string operation)
  {
    Console.WriteLine($"Email: Hello, {identifier} has been successfully {operation} the Library. If you have any queries or feedback, please contact our support team at support@library.com.\n");
  }

  public void SendNotificationOnFailure(string identifier, string operation)
  {
    Console.WriteLine($"Email: We encountered an issue, {identifier} {operation}. Please review the input data.For more help, visit our FAQ at library.com / faq.\n");
  }
}


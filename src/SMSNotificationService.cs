namespace NotificationService;

public class SMSNotificationService : INotificationService
{
  public void SendNotificationOnSuccess(string identifier, string operation)
  {
    Console.WriteLine($"SNS: {identifier} {operation} Library successfully.\n");
  }

  public void SendNotificationOnFailure(string identifier, string error)
  {
    Console.WriteLine($"SNS: Error - {identifier} {error}.\n");
  }
}
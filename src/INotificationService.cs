namespace NotificationService;

public interface INotificationService
{
  public void SendNotificationOnSuccess(string identifier, string operation);
  public void SendNotificationOnFailure(string identifier, string operation);
}
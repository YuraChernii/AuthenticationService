namespace Domain.Services
{
    public interface INotificationService
    {
        Task SendMessageAsync(string message);
    }
}
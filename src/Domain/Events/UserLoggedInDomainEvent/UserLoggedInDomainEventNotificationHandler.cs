using Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Domain.Events.UserLoggedInDomainEvent
{
    internal class UserLoggedInDomainEventNotificationHandler : INotificationHandler<UserLoggedInDomainEvent>
    {
        private readonly ILogger logger;
        private readonly INotificationService notificationService;

        public UserLoggedInDomainEventNotificationHandler(
            INotificationService notificationService, 
            ILoggerFactory loggerFactory)
        {
            this.notificationService = notificationService;
            logger = loggerFactory.CreateLogger<UserLoggedInDomainEventNotificationHandler>();
        }

        public async Task Handle(UserLoggedInDomainEvent notification, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(notification);

            await notificationService.SendMessageAsync(JsonSerializer.Serialize(notification));
            logger.LogInformation($"UserLoggedIn notification was sent.");
        }
    }
}

using MediatR;

namespace Domain.Events
{
    internal class UserEnteredInvalidPasswordDomainEvent : INotification
    {
        public Guid UserId { get; }
        public DateTime EnteredAt { get; }

        public UserEnteredInvalidPasswordDomainEvent(Guid userId, DateTime attemptedAt)
        {
            UserId = userId;
            EnteredAt = attemptedAt;
        }
    }
}
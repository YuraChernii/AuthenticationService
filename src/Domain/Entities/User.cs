using Core.Entities.Base;
using Core.Enums;
using Domain.Events;
using Domain.Events.UserLoggedInDomainEvent;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        //private User() { }

        public User(string userName, string firstName, string lastName, string email, Gender gender, Guid id = default)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Gender Gender { get; private set; }
        public DateTime LastLoginTime { get; private set; }

        public bool VerifyPassword(Func<string, string, bool> verify, string password)
        {
            if (!verify(Password, password))
            {
                DomainEvents.Add(new UserEnteredInvalidPasswordDomainEvent(Id, DateTime.UtcNow));

                return false;
            }

            return true;
        }

        public string Login(Func<string, string> generateToken)
        {
            LastLoginTime = DateTime.UtcNow;
            DomainEvents.Add(new UserLoggedInDomainEvent(Id, DateTime.UtcNow));

            return generateToken(UserName);
        }
    }
}
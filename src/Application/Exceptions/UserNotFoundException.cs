using Domain.Exceptions.Base;

namespace Application.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userName)
            : base($"User with UserName: '{userName}' was not found.")
        {
        }
    }
}
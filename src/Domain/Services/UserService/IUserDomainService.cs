using Core.Entities;

namespace Core.Services.UserService
{
    public interface IUserDomainService
    {
        string Login(User user, string password);
    }
}
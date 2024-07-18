using Core.Entities;
using Core.Exceptions;
using Domain.Services;

namespace Core.Services.UserService
{
    internal class UserDomainService(
        IPasswordHashingService passwordHashingService,
        ITokenService tokenService) 
        : IUserDomainService
    {
        public string Login(User user, string password)
        {
            if (!user.VerifyPassword(passwordHashingService.VerifyPassword, password))
            {
                throw new InvalidPasswordException();
            }

            return user.Login(tokenService.GenerateToken);
        }
    }
}
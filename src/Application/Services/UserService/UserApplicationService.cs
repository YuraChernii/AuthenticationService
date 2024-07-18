using Application.DTOs;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;
using Core.Services.UserService;

namespace Application.Services.UserService
{
    internal class UserApplicationService(
        IUserRepository userRepository,
        IUserDomainService userDomainService)
        : IUserApplicationService
    {
        public async Task<UserProfileDTO> LoginAsync(LoginParameters parameters)
        {
            User user = await userRepository.GetUserAsync(parameters.UserName)
                ?? throw new UserNotFoundException(parameters.UserName);
            string token = userDomainService.Login(user, parameters.Password);
            await userRepository.SaveChangesAsync();

            return new()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Token = token
            };
        }
    }
}
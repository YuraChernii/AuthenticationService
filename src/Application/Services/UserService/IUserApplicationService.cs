using Application.DTOs;

namespace Application.Services.UserService
{
    public interface IUserApplicationService
    {
        Task<UserProfileDTO> LoginAsync(LoginParameters parameters);
    }

    public class LoginParameters
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

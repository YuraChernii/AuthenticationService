using Application.DTOs;
using MediatR;

namespace Application.Commands.Login
{
    public class LoginCommand : IRequest<UserProfileDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
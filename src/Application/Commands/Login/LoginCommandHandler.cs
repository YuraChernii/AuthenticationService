using Application.DTOs;
using Application.Services.UserService;
using AutoMapper;
using MediatR;

namespace Application.Commands.Login
{
    public class LoginCommandHandler(
        IUserApplicationService userApplicationService, 
        IMapper mapper) 
        : IRequestHandler<LoginCommand, UserProfileDTO>
    {
        public async Task<UserProfileDTO> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(command);
            ArgumentException.ThrowIfNullOrEmpty(command.UserName);
            ArgumentException.ThrowIfNullOrEmpty(command.Password);

            return await userApplicationService.LoginAsync(mapper.Map<LoginParameters>(command));
        }
    }
}
using Application.Commands.Login;
using Application.DTOs;
using Application.Services.UserService;
using AutoMapper;
using Moq;

namespace Auth
{
    public class LoginCommandHandlerTests
    {
        private readonly Mock<IUserApplicationService> mockUserApplicationService = new();
        private readonly Mock<IMapper> mockMapper = new();
        private readonly LoginCommandHandler handler;

        public LoginCommandHandlerTests()
        {
            handler = new(mockUserApplicationService.Object, mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldThrowArgumentNullException_WhenCommandIsNull() =>
            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(null, CancellationToken.None));

        [Fact]
        public async Task Handle_ShouldThrowArgumentException_WhenUserNameIsNullOrEmpty()
        {
            LoginCommand command = new() { UserName = "", Password = "password" };

            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldThrowArgumentException_WhenPasswordIsNullOrEmpty()
        {
            LoginCommand command = new() { UserName = "username", Password = "" };

            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ShouldReturnUserProfileDTO_WhenCommandIsValid()
        {
            LoginCommand command = new() { UserName = "username", Password = "password" };
            UserProfileDTO expectedUserProfileDTO = new();
            mockMapper.Setup(m => m.Map<LoginParameters>(command)).Returns(new LoginParameters());
            mockUserApplicationService.Setup(s => s.LoginAsync(It.IsAny<LoginParameters>()))
                .ReturnsAsync(expectedUserProfileDTO);

            UserProfileDTO result = await handler.Handle(command, CancellationToken.None);

            Assert.Equal(expectedUserProfileDTO, result);
            mockMapper.Verify(m => m.Map<LoginParameters>(command), Times.Once);
            mockUserApplicationService.Verify(s => s.LoginAsync(It.IsAny<LoginParameters>()), Times.Once);
        }
    }
}
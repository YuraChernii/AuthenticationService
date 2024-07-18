using Application.Commands.Login;
using Application.Services.UserService;
using AutoMapper;

namespace Application.MapProfiles
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            AllowNullCollections = false;
            ShouldMapProperty = p => true;

            CreateMap<LoginCommand, LoginParameters>();
        }
    }
}
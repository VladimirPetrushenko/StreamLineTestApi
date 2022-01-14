using AutoMapper;
using StreamLineTestApi.Client.Models.Dto.Users;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserReadDto>();
        }
    }
}

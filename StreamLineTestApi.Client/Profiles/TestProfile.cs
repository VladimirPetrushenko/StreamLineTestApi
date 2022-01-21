using AutoMapper;
using StreamLineTestApi.Client.Models.Dto.Test;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Profiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<TestCreateDto, Test>();
            CreateMap<Test, TestReadDto>();
        }
    }
}

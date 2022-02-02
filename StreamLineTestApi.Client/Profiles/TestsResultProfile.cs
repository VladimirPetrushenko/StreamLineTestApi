using AutoMapper;
using StreamLineTestApi.Client.Models.Dto.Result;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Profiles
{
    public class TestsResultProfile : Profile
    {
        public TestsResultProfile()
        {
            CreateMap<TestsResult, ResultReadDto>();
        }
    }
}

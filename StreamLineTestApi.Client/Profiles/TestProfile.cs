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

            CreateMap<TestUpdateDto, Test>()
                .ForMember(x => x.Questions, opt => opt.Ignore());

            CreateMap<Test, TestReadDto>();
            CreateMap<Test, TestReadNameAndIDDto>();


            CreateMap<Test, TestUpdateReadDto>();
        }
    }
}

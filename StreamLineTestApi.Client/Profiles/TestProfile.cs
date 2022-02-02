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

            CreateMap<TestUpdateDto, Test>();

            CreateMap<Test, TestReadDto>();
            CreateMap<Test, TestReadNameIDQuestionCountDto>()
                .ForMember(x=>x.QuestionCount, opt => opt.MapFrom(y => y.Questions.Count));


            CreateMap<Test, TestUpdateReadDto>();
        }
    }
}

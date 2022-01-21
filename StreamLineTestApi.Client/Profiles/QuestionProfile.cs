using AutoMapper;
using StreamLineTestApi.Client.Models.Dto.Question;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionCreateDto, TestsQuestion>();
            CreateMap<TestsQuestion, QuestionReadDto>();
        }
    }
}

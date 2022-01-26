using AutoMapper;
using StreamLineTestApi.Client.Models.Dto.Answer;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Profiles
{
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            CreateMap<AnswerCreateDto, QuestionsAnswer>();
            CreateMap<AnswerUpdateDto, QuestionsAnswer>();
            CreateMap<QuestionsAnswer, AnswerReadDto>();
        }
    }
}

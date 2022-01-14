using AutoMapper;
using StreamLineTestApi.Client.Models.Dto.QuestionType;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Profiles
{
    public class QuestionsTypeProfile : Profile
    {
        public QuestionsTypeProfile()
        {
            CreateMap<QuestionsTypeReadDto, QuestionsType>();
            CreateMap<QuestionsType, QuestionsTypeReadDto>();
        }
    }
}

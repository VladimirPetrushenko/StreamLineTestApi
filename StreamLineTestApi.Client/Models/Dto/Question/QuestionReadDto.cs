using StreamLineTestApi.Client.Models.Dto.Answer;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Models.Dto.Question
{
    public class QuestionReadDto
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<AnswerReadDto> Answers { get; set; }
        public QuestionsType Type { get; set; }
    }
}

using StreamLineTestApi.Client.Models.Dto.Answer;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.Models.Dto.Question
{
    public class QuestionUpdateReadDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<AnswerUpdateReadDto> Answers { get; set; }
        public QuestionsType Type { get; set; }
    }
}

using StreamLineTestApi.Client.Models.Dto.Answer;
using StreamLineTestApi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Question
{
    public class QuestionCreateDto
    {
        [Required]
        public string Value { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
        public QuestionsType Type { get; set; }
    }
}

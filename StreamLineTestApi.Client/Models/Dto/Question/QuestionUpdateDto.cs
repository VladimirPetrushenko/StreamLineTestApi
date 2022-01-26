using StreamLineTestApi.Client.Models.Dto.Answer;
using StreamLineTestApi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Question
{
    public class QuestionUpdateDto
    {
        [Required]
        public string Question { get; set; }
        public List<AnswerUpdateDto> Answers { get; set; }
        public QuestionsType Type { get; set; }
    }
}

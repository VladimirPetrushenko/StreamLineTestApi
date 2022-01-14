using StreamLineTestApi.Client.Models.Dto.Answer;
using StreamLineTestApi.Client.Models.Dto.QuestionType;
using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Question
{
    public class QuestionCreateDto
    {
        [Required]
        public string Question { get; set; }
        public List<AnswerCreateDto> Answers { get; set; }
        public QuestionsTypeReadDto Type { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.QuestionType
{
    public class QuestionsTypeReadDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}

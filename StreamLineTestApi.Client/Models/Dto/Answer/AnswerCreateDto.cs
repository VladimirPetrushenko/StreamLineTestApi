using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Answer
{
    public class AnswerCreateDto
    {
        [Required]
        public string Answer { get; set; }
        [Required]
        public bool IsRight { get; set; }
    }
}

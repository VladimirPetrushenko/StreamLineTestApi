using StreamLineTestApi.Client.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Answer
{
    public class AnswerUpdateDto
    {
        public string Value { get; set; }
        [Required]
        public bool IsRight { get; set; }
    }
}

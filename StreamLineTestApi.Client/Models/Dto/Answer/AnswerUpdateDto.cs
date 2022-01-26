using StreamLineTestApi.Client.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Answer
{
    public class AnswerUpdateDto : IId
    {
        [Required]
        public int Id { get; set; }
        public string Answer { get; set; }
        [Required]
        public bool IsRight { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Question
{
    public class QuestionDeleteDto
    {
        [Required]
        public int Id { get; set; }
    }
}

using StreamLineTestApi.Client.Models.Dto.Question;
using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Test
{
    public class TestUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<QuestionUpdateDto> Questions { get; set; }
    }
}

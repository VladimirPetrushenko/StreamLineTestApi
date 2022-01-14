using StreamLineTestApi.Client.Models.Dto.Question;
using System.ComponentModel.DataAnnotations;

namespace StreamLineTestApi.Client.Models.Dto.Test
{
    public class TestCreateDto
    {
        [Required]
        public string Name { get; set; }
        public List<QuestionCreateDto> Questions { get; set; }
    }
}

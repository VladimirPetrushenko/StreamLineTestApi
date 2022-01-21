using StreamLineTestApi.Client.Models.Dto.Question;

namespace StreamLineTestApi.Client.Models.Dto.Test
{
    public class TestReadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<QuestionReadDto> Questions { get; set; }
    }
}

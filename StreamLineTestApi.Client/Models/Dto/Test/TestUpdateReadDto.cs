using StreamLineTestApi.Client.Models.Dto.Question;

namespace StreamLineTestApi.Client.Models.Dto.Test
{
    public class TestUpdateReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionUpdateReadDto> Questions { get; set; }
    }
}

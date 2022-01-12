namespace StreamLineTestApi.Domain.Models
{
    public class QuestionsType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<TestsQuestion> Questions { get; set; }
    }
}

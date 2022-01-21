namespace StreamLineTestApi.Domain.Models
{
    public class TestsQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public List<QuestionsAnswer> Answers { get; set; }
        public QuestionsType Type { get; set; }
        public Test Test { get; set; }

        public TestsQuestion()
        {
            Test = new Test();
            Type = QuestionsType.Single;
            Answers = new List<QuestionsAnswer>();
            Question = string.Empty;
        }
    }
}

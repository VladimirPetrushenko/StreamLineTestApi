namespace StreamLineTestApi.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<QuestionsAnswer> Answers { get; set; }
        public QuestionsType Type { get; set; }
        public List<Test> Tests { get; set; }

        public Question()
        {
            Tests = new List<Test>();
            Type = QuestionsType.Single;
            Answers = new List<QuestionsAnswer>();
            Value = string.Empty;
        }
    }
}

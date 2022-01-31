namespace StreamLineTestApi.Domain.Models
{
    public class QuestionsAnswer
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsRight { get; set; }
        public Question Question { get; set; }

        public QuestionsAnswer()
        {
            Question = new Question();
            Value = string.Empty;
        }
    }
}

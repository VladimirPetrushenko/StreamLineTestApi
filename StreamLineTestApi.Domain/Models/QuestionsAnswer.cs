namespace StreamLineTestApi.Domain.Models
{
    public class QuestionsAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsRight { get; set; }
        public TestsQuestion Question { get; set; }
    }
}

namespace StreamLineTestApi.Domain.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<TestsResult> Results { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            Results = new List<TestsResult>();
        }
    }
}

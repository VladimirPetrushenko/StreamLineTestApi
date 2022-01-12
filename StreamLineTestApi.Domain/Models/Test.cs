namespace StreamLineTestApi.Domain.Models
{
    public class Test
    {
        public int Id { get; set; }
        public List<TestsQuestion> Questions { get; set; }
        public List<TestsResult> Results { get; set; }
    }
}

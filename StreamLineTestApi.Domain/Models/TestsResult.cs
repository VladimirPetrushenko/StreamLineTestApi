namespace StreamLineTestApi.Domain.Models
{
    public class TestsResult
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Test Test { get; set; }
        public double Result { get; set; }

        public TestsResult()
        {
            User = new User();
            Test = new Test();
        }
    }
}

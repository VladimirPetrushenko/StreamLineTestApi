namespace StreamLineTestApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TestsResult> Results { get; set; }

        public User()
        {
            Name = String.Empty;
            Email = String.Empty;  
            Password = String.Empty;
            Results = new List<TestsResult>();
        }
    }
}

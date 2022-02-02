using StreamLineTestApi.Client.Models.Dto.Test;

namespace StreamLineTestApi.Client.Models.Dto.Result
{
    public class ResultReadDto
    {
        public TestReadNameIDQuestionCountDto Test { get; set; }
        public double Result { get; set; }
    }
}

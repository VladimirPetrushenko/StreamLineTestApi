using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Helpers
{
    internal class TestValidator
    {
        private readonly List<Question> questions;
        private readonly List<string> answers;
        private readonly bool[] result;
        private bool canReadResult = false;

        public TestValidator(List<Question> questions, List<string> answers)
        {
            this.questions = questions;
            this.answers = answers;
            result = new bool[questions.Count];
        }

        public double Check()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(answers[i]))
                {
                    continue;
                }

                var rightAnswer = questions[i].Answers.First(a => a.IsRight);

                if (rightAnswer.Value.Contains(answers[i]))
                {
                    result[i] = true;
                }
            }
            canReadResult = true;
            return result.Where(r => r == true).Count() * 1.0 / result.Count();
        }

        public bool[] GetResult()
        {
            if (canReadResult)
            {
                return result;
            }
            throw new InvalidOperationException();
        }
    }
}

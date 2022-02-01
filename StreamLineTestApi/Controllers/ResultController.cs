using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StreamLineTestApi.Client.Models.Dto.Result;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Controllers
{
    public class ResultController : Controller
    {
        private readonly IRepository<Test> _testRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<TestsResult> _testsResultRepo;
        private readonly IMapper _mapper;

        public ResultController(
            IRepository<Test> testRepo,
            IMapper mapper,
            IRepository<User> userRepo)
        {
            _testRepo = testRepo;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("CheckTest")]
        public async Task<IActionResult> CheckTest(ResultCreateDto resultRead)
        {
            var test = await _testRepo.GetByID(resultRead.Id);
            var userNoTracking = (await _userRepo.GetAll()).Where(u => u.Name == resultRead.UserName).FirstOrDefault();

            if (test == null || userNoTracking == null)
            {
                return BadRequest();
            }

            var user = await _userRepo.GetByID(userNoTracking.Id);
            bool[] result = new bool[test.Questions.Count];

            for (int i = 0; i < test.Questions.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(resultRead.Answers[i]))
                {
                    continue;
                }

                var rightAnswer = test.Questions[i].Answers.FirstOrDefault(a => a.IsRight);

                if (rightAnswer == null)
                {
                    continue;
                }

                if (rightAnswer.Value.Contains(resultRead.Answers[i]))
                {
                    result[i] = true;
                }
            }

            var testsResult = new TestsResult();
            testsResult.Test = test;
            testsResult.User = user;

            testsResult.Result = result.Where(r => r == true).Count() * 1.0 / result.Count();

            await _testsResultRepo.CreateItem(testsResult);
            await _testsResultRepo.SaveChanges();

            return Json(result);
        }
    }
}

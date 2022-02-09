using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StreamLineTestApi.Client.Models.Dto.Result;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;
using StreamLineTestApi.Helpers;

namespace StreamLineTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ResultController : Controller
    {
        private readonly IRepository<Test> _testRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<TestsResult> _testsResultRepo;
        private readonly IMapper _mapper;

        public ResultController(
            IRepository<Test> testRepo,
            IMapper mapper,
            IRepository<User> userRepo, 
            IRepository<TestsResult> testsResultRepo)
        {
            _testRepo = testRepo;
            _mapper = mapper;
            _userRepo = userRepo;
            _testsResultRepo = testsResultRepo;
        }

        [HttpPost]
        [Route("CheckTest")]
        public async Task<IActionResult> CheckTest(ResultCreateDto resultRead)
        {
            var test = await _testRepo.GetByID(resultRead.TestId);
            var user = await GetCurrentUser();
            
            if (test == null || user == null)
            {
                return BadRequest();
            }

            var testValidator = new TestValidator(test.Questions, resultRead.Answers);

            if(await ExistTestsResult(user, test.Id))
            {
                await UpdateTestsResultIfResultGreaterPrevious(test, user, testValidator);
            }
            else
            {
                await CreateTestsResult(test, user, testValidator);
            }

            return Json(testValidator.GetResult());
        }

        private async Task UpdateTestsResultIfResultGreaterPrevious(Test test, User user, TestValidator testValidator)
        {
            var testsResultNoTracking = await GetTestsResult(user, test.Id);
            var testsResult = await _testsResultRepo.GetByID(testsResultNoTracking.Id);

            if (testsResult == null)
            {
                throw new Exception();
            }

            var result = testValidator.Check();

            if (testsResult.Result < result)
            {
                testsResult.Result = result;
            }

            await _testsResultRepo.UpdateItem(testsResult);
        }

        private async Task CreateTestsResult(Test test, User user, TestValidator testValidator)
        {
            var testsResult = new TestsResult()
            {
                Test = test,
                User = await _userRepo.GetByID(user.Id) ?? (await _userRepo.GetAll()).First(),
                Result = testValidator.Check(),
            };

            await _testsResultRepo.CreateItem(testsResult);
        }

        [HttpGet]
        public async Task<IActionResult> Results()
        {
            var user = await GetCurrentUser();

            if(user == null)
            {
                return NotFound();
            }

            var results = await GetUserResults(user);
            var resultReadDto = _mapper.Map<List<ResultReadDto>>(results);

            return Json(resultReadDto);
        }

        private async Task<User?> GetCurrentUser()
        {
            if (HttpContext.User.Identity == null)
            {
                throw new Exception();
            }

            var userName = HttpContext.User.Identity.Name;
            var userNoTracking = (await _userRepo.GetAll()).Where(u => u.Name == userName).FirstOrDefault();

            return userNoTracking;
        }

        private async Task<IEnumerable<TestsResult>> GetUserResults(User user) =>
            (await _testsResultRepo.GetAll()).Where(x => x.User.Id == user.Id);

        private async Task<bool> ExistTestsResult(User user, int testId)
        {
            var results = await GetUserResults(user);

            if (results == null)
            {
                return false;
            }

            return results.Count(x=>x.Test.Id == testId) > 0;
        }

        private async Task<TestsResult> GetTestsResult(User user, int testId)
        {
            var results = await GetUserResults(user);

            return results.Where(x => x.Test.Id == testId).First();
        }
    }
}

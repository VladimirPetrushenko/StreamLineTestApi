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
            var userNoTracking = await GetCurrentUser();

            if (test == null || userNoTracking == null)
            {
                return BadRequest();
            }

            var testValidator = new TestValidator(test.Questions, resultRead.Answers);

            //var testsResult = new TestsResult()
            //{
            //    Test = test,
            //    User = await _userRepo.GetByID(userNoTracking.Id) ?? (await _userRepo.GetAll()).First(),
            //    Result = testValidator.Check(),
            //};

            //await _testsResultRepo.CreateItem(testsResult);
            //await _testsResultRepo.SaveChanges();
            testValidator.Check();
            return Json(testValidator.GetResult());
        }

        [HttpGet]
        public async Task<IActionResult> Results()
        {
            var user = await GetCurrentUser();

            if(user == null)
            {
                return NotFound();
            }

            var results = (await _testsResultRepo.GetAll()).Where(x => x.User.Id == user.Id);
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
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StreamLineTestApi.Client.Models.Dto.Test;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IRepository<Test> _repository;
        private readonly IMapper _mapper;

        public TestController(IRepository<Test> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(TestCreateDto testCreateDto)
        {
            if (!testCreateDto.Questions.Any())
            {
                return BadRequest();
            }

            var test = _mapper.Map<Test>(testCreateDto);

            await _repository.CreateItem(test);
            await _repository.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("CheckTest")]
        public async Task<IActionResult> CheckTest(TestCheckResultDto testCheckResult)
        {
            var test = await _repository.GetByID(testCheckResult.Id);

            if(test == null)
            {
                return BadRequest();
            }

            bool[] result = new bool[test.Questions.Count];

            for (int i = 0; i < test.Questions.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(testCheckResult.Answers[i]))
                {
                    continue;
                }

                var rightAnswer = test.Questions[i].Answers.FirstOrDefault(a => a.IsRight);

                if(rightAnswer == null)
                {
                    continue;
                }

                if(rightAnswer.Answer.Contains(testCheckResult.Answers[i]))
                {
                    result[i] = true;
                }
            }

            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> Tests()
        {
            var tests = await _repository.GetAll();
            var testsDto = _mapper.Map<List<TestsReadDto>>(tests);

            return Ok(testsDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTest()
        {
            var test = await _repository.GetByID(1);

            return Ok(test);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Test(int Id)
        {
            var test = await _repository.GetByID(Id);

            var testDto = _mapper.Map<TestReadDto>(test);

            return Ok(testDto);
        }
    }
}

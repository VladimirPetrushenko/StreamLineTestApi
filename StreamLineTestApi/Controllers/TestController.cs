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

        public TestController(
            IRepository<Test> repository,
            IMapper mapper
           )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Tests()
        {
            var tests = await _repository.GetAll();
            var testsDto = _mapper.Map<List<TestReadNameAndIDDto>>(tests);

            return Ok(testsDto);
        }


        [HttpGet("id")]
        public async Task<IActionResult> Test(int Id)
        {
            var test = await _repository.GetByID(Id);

            var testDto = _mapper.Map<TestReadDto>(test);

            return Ok(testDto);
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

        [HttpGet("update/id")]
        public async Task<IActionResult> UpdateTest(int Id)
        {
            var test = await _repository.GetByID(Id);

            var testDto = _mapper.Map<TestUpdateReadDto>(test);

            return Ok(testDto);
        }

        [HttpPut("update/id")]
        public async Task<IActionResult> UpdateTest(int id, TestUpdateDto testUpdate)
        {
            var test = await _repository.GetByID(id);

            if (test == null)
            {
                return NotFound();
            }

            _mapper.Map(testUpdate, test);

            await _repository.SaveChanges();

            var testDto = _mapper.Map<TestReadDto>(test);

            return Ok(testDto);
        }

        [HttpPost]
        [Route("CheckTest")]
        public async Task<IActionResult> CheckTest(TestCheckResultDto testCheckResult)
        {
            var test = await _repository.GetByID(testCheckResult.Id);

            if (test == null)
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

                if (rightAnswer == null)
                {
                    continue;
                }

                if (rightAnswer.Value.Contains(testCheckResult.Answers[i]))
                {
                    result[i] = true;
                }
            }

            return Json(result);
        }
    }
}

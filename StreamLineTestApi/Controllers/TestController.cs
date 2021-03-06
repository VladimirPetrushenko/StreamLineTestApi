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
            var testsDto = _mapper.Map<List<TestReadNameIDQuestionCountDto>>(tests);

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

            return Ok();
        }

        [HttpPost]
        [Route("CreateWithConstructor")]
        public async Task<IActionResult> CreateWithConstructor(TestCreateDto testCreateDto)
        {
            if (!testCreateDto.Questions.Any())
            {
                return BadRequest();
            }

            var test = new Test() { Name = testCreateDto.Name };

            var testEntity = await _repository.CreateItem(test);

            test = await _repository.GetByID(testEntity.Id);

            _mapper.Map(testCreateDto, test);

            await _repository.UpdateItem(test);

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

            await _repository.UpdateItem(test);

            var testDto = _mapper.Map<TestReadDto>(test);

            return Ok(testDto);
        }
        
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(TestDeleteDto testDeleteDto)
        {
            var test = await _repository.GetByID(testDeleteDto.Id);

            if (test == null)
            {
                return BadRequest();
            }

            await _repository.DeleteItem(test);
            
            return Ok();
        }
    }
}

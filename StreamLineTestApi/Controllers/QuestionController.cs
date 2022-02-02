using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StreamLineTestApi.Client.Models.Dto.Question;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        private readonly IRepository<Question> _repository;
        private readonly IMapper _mapper;

        public QuestionController(IRepository<Question> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionCreateDto questionCreateDto)
        {
            var question = _mapper.Map<Question>(questionCreateDto);

            await _repository.CreateItem(question);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Questions()
        {
            var questions = await _repository.GetAll();
            var questionsDto = _mapper.Map<List<QuestionReadDto>>(questions);

            return Ok(questionsDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteQuestion(QuestionDeleteDto questionDeleteDto)
        {
            var question = await _repository.GetByID(questionDeleteDto.Id);
            
            if(question == null)
            {
                return BadRequest();
            }

            await _repository.DeleteItem(question);

            return Ok();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StreamLineTestApi.Client.Models.Dto.Question;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IRepository<TestsQuestion> _repository;
        private readonly IMapper _mapper;

        public QuestionController(IRepository<TestsQuestion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(QuestionCreateDto questionCreateDto)
        {
            var question = _mapper.Map<TestsQuestion>(questionCreateDto);

            await _repository.CreateItem(question);
            await _repository.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }
    }
}

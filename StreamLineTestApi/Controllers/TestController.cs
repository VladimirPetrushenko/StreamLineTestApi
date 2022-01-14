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
        public async Task<IActionResult> Create(TestCreateDto testCreateDto)
        {
            var question = _mapper.Map<Test>(testCreateDto);

            await _repository.CreateItem(question);
            await _repository.SaveChanges();

            return Ok();
        }
    }
}

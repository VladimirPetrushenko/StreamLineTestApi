using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StreamLineTestApi.Client.Models.Dto.Users;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StreamLineTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Json("Hello world");
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = (await _repository.GetAll())
                .FirstOrDefault(u => u.Name == userLoginDto.Name && u.Password == userLoginDto.Password);

            if (user == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }


            var userReadDto = _mapper.Map<UserReadDto>(user);
            userReadDto.AccessToken = GetToken(GetClaimsIdentity(user.Name));

            return Json(userReadDto);
        }

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register(UserCreateDto createUserDto)
        {
            var userModel = _mapper.Map<User>(createUserDto);
            
            await _repository.CreateItem(userModel);
            
            if (!(await _repository.SaveChanges()))
            {
                return BadRequest(new { errorText = "Username already exists." });
            }

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            userReadDto.AccessToken = GetToken(GetClaimsIdentity(userModel.Name));

            return Json(userReadDto);
        }

        private static string GetToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private static ClaimsIdentity GetClaimsIdentity(string username = "")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };

            var claimsIdentity =
                new ClaimsIdentity (
                    claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType
                    );

            return claimsIdentity;
        }
    }
}

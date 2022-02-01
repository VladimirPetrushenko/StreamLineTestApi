using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity == null)
            {
                return NotFound();
            }

            var user = HttpContext.User.Identity.Name;
            return Json(user);
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

            var token = GetToken(GetClaimsIdentity(user.Name));
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token, new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(AuthOptions.LIFETIME)
            });

            var userReadDto = _mapper.Map<UserReadDto>(user);
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

            var token = GetToken(GetClaimsIdentity(userModel.Name));
            HttpContext.Response.Cookies.Append(".AspNetCore.Application.Id", token, new CookieOptions
            {
                MaxAge = TimeSpan.FromMinutes(AuthOptions.LIFETIME)
            });

            var userReadDto = _mapper.Map<UserReadDto>(userModel);
            return Json(userReadDto);
        }

        [HttpGet]
        [Authorize]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete(".AspNetCore.Application.Id");
            return Ok();
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

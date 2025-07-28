using Autenticacao.Data;
using Autenticacao.Dtos;
using Autenticacao.Helpers;
using Autenticacao.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    [Route("api")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtServices _jwtService;
        public AuthController(IUserRepository repository, JwtServices jwtServices)
        {
            _repository = repository;
            _jwtService = jwtServices;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _repository.Create(user);

            return Created("Sucess", _repository.Create(user));
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user == null)
            {
                return BadRequest(new { messager = "credênciais inválidas." });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { messager = "credênciais inválidas." });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "Sucesso"
            });
        }
    }
}

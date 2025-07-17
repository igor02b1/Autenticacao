using Autenticacao.Data;
using Autenticacao.Dtos;
using Autenticacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    [Route("api")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository)
        {
            _repository = repository;
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
    }
}

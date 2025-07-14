using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    public class AuthController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Sucess");
        }
    }
}

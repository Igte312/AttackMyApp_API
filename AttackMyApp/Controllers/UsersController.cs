using Aplication.InterfaceService;
using Aplication.Request.Users;
using Microsoft.AspNetCore.Mvc;

namespace AttackMyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService) 
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            var response = _usersService.CreateUser(request);

            return Ok(new { UserId = response });
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            // Obtén el valor de la variable de entorno
            var testVariable = Environment.GetEnvironmentVariable("TEST_VARIABLE");

            // Devuelve el valor de la variable de entorno en la respuesta
            return Ok($"La API está funcionando correctamente. Valor de TEST_VARIABLE: {testVariable}");
        }
    }
}

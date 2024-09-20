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
            var testVariable = Environment.GetEnvironmentVariable("DB_HOST");
            Console.WriteLine("DB_HOST: " + Environment.GetEnvironmentVariable("DB_HOST"));
            Console.WriteLine("DB_NAME: " + Environment.GetEnvironmentVariable("DB_NAME"));
            Console.WriteLine("DB_PORT: " + Environment.GetEnvironmentVariable("DB_PORT"));
            Console.WriteLine("DB_USER: " + Environment.GetEnvironmentVariable("DB_USER"));
            Console.WriteLine("DB_PASSWORD: " + Environment.GetEnvironmentVariable("DB_PASSWORD"));
            // Devuelve el valor de la variable de entorno en la respuesta
            return Ok($"La API está funcionando correctamente. Valor de DB_HOST: {testVariable}");
        }
    }
}

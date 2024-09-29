using Aplication.InterfaceService;
using Aplication.Request.Users;
using Aplication.Service;
using Microsoft.AspNetCore.Mvc;

namespace AttackMyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : Controller
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService) 
        {
            _userTypeService = userTypeService;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] CreateUserTypeRequest request)
        {
            var response = _userTypeService.CreateUserType(request);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}

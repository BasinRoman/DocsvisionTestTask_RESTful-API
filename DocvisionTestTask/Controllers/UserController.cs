using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocvisionTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var response = _userService.GetAllUsers();
            //тут нужно вернуть json
            return null;
        }
    }
}

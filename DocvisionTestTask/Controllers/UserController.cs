using Business.Interfaces;
using DocvisionTestTask.Domain.Model;
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

        //Получаем список всех записей таблицы Users
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult GetProfiles()
        {
            var response =  _userService.GetAllUsers(); 
            if (response.statusCode != Domain.Entity.StatusCode.internalServiceError)
            {
                return null;
            }
            return null;
        }
        
    }
}

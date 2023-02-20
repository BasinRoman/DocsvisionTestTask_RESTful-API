using Business.Implementations;
using Business.Interfaces;
using DocvisionTestTask.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace DocvisionTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        //Получаем список всех записей таблицы Profiles
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult GetProfiles()
        {
            var response = _profileService.GetAllProfiles();
            return Ok(response.ToJson());
        }
    }
}

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProfileModel>))]
        [HttpGet]
        public IActionResult GetProfiles()
        {
            var response = _profileService.GetAllProfiles();
            if (response.statusCode == Domain.Response.StatusCode.ok)
            {
                return Ok(response.ToJson());
            }
            return BadRequest("Не удалось получить список профилей");
        }
    }
}

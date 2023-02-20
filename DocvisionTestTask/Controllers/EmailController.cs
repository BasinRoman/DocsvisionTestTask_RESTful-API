using Business.Interfaces;
using DocvisionTestTask.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocvisionTestTask.Domain.Entity;
using Microsoft.OpenApi.Writers;
using Microsoft.AspNetCore.Http.HttpResults;
using Business.Implementations;

namespace DocvisionTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        //Принимаем json и отправляем в inbox
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmailModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<EmailModel>> CreateEmail(EmailModel email)
        {
            if (email != null)
            {
                var resposne = await _emailService.CreateNewInBox(email);
                if (resposne.statusCode == Domain.Entity.StatusCode.ok)
                {
                    return Ok($"{resposne.Description}");
                }
                return BadRequest("Ошибка при отправке письма");
            }
            return BadRequest("Ошибка при отправке письма. Пустое сообщение.");
        }
    }
}

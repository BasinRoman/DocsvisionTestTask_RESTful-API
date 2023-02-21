using Business.Interfaces;
using DocvisionTestTask.Domain.Model;
using Microsoft.AspNetCore.Mvc;


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
        [HttpPost]
        public async Task<ActionResult<EmailModel>> CreateEmail(EmailModel email)
        {
            if (email != null)
            {
                if (ModelState.IsValid)
                {
                    var resposne = await _emailService.CreateNewInBox(email);
                    if (resposne.statusCode == Domain.Response.StatusCode.ok)
                    {
                        return Ok($"{resposne.Description}");
                    }
                }
                return BadRequest($"Ошибка при отправке письма\n{ModelState}");
            }
            return BadRequest("Ошибка при отправке письма. Пустое сообщение.");
        }
    }
}

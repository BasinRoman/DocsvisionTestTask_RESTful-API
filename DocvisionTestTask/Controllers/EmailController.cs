using Business.Interfaces;
using DocvisionTestTask.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocvisionTestTask.Domain.Entity;
using Microsoft.OpenApi.Writers;


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
        [HttpPost]        
        public async Task<IActionResult> CreateEmail(EmailModel email)
        {
            if (ModelState.IsValid)
            {
                var resposne = await _emailService.CreateNewInBox(email);
                if (resposne.statusCode == Domain.Entity.StatusCode.ok)
                {
                    return ;
                }
                
                return ;
            }
            return ;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(User user)
        {
            ///
        }
    }
}

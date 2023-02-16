using Business.Interfaces;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using DocvisionTestTask.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IInBoxRepository _InBoxRepository;
        public EmailService(IInBoxRepository InBoxRepository)
        {
            _InBoxRepository = InBoxRepository;
        }
        public async Task<IBaseResponse<InBox>> CreateNewInBox(EmailModel email)
        {
            var baseResponse = new BaseResponse<InBox>();
            try
            {
                var NewEmail = new InBox
                {
                    Email_date = email.Email_date,
                    Email_from = email.Email_from,
                    Email_to = email.Email_to,
                    Email_body = email.Email_body,
                    Email_subject = email.Email_subject,
                };
                bool request = await _InBoxRepository.Create(NewEmail);
                if (!request)
                {
                    baseResponse.statusCode = StatusCode.InternalServiceError;
                    baseResponse.Description = $"A try to store new email with id {NewEmail.Id} failed";
                    return baseResponse;
                }
                baseResponse.Description = $"A try to store new email with id {NewEmail.Id} succesful";
                baseResponse.statusCode = StatusCode.ok;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<InBox>() { Description = ex.Message };
            }
        }  
    }
}

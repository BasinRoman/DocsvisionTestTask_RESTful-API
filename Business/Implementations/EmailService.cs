using Business.Interfaces;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using DocvisionTestTask.Domain.Response;


namespace Business.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IInBoxRepository _InBoxRepository;
        private readonly IUserService _userService;
        public EmailService(IInBoxRepository InBoxRepository, IUserService userService)
        {
            _InBoxRepository = InBoxRepository;
            _userService = userService;
        }

        public async Task<IBaseResponse<inBox>> CreateNewInBox(EmailModel email)
        {
            var baseResponse = new BaseResponse<inBox>();
            try
            {
                var _userId = await _userService.GetUserByFNameLame(email.emailTo);
                int newId;
                if (_userId.statusCode == StatusCode.internalServiceError)
                {
                    newId = 1;
                }
                else
                {
                    newId = _userId.Data.id;
                }
                var newInbox = new inBox
                {
                    userId = newId,
                    emailDate = email.emailDate,
                    emailFrom = email.emailFrom,
                    emailTo = email.emailTo,
                    emailBody = email.emailBody,
                    emailSubject = email.emailSubject,
                };
                bool request = await _InBoxRepository.Create(newInbox);
                if (!request)
                {
                    baseResponse.Data = newInbox;
                    baseResponse.statusCode = StatusCode.internalServiceError;
                    baseResponse.Description = $"Не удалось отправить письмо адресованное пользователю [ {newInbox.emailTo} ].\n";
                    return baseResponse;
                }
                baseResponse.Data = newInbox;
                baseResponse.Description = $"Письмо адресованное пользователю [ {newInbox.emailTo} ] успешно доставлено.\n{_userId.Description}";
                baseResponse.statusCode = StatusCode.ok;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<inBox>() { Description = ex.Message };
            }
        }  
        
    }
}

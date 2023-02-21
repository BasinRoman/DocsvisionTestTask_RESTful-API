using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using DocvisionTestTask.Domain.Response;

namespace Business.Interfaces
{
    public interface IEmailService
    {
        Task<IBaseResponse<inBox>> CreateNewInBox(EmailModel email);
    }
}

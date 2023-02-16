using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using DocvisionTestTask.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEmailService
    {
        Task<IBaseResponse<InBox>> CreateNewInBox(EmailModel email);
    }
}

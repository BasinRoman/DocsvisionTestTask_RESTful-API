using DocvisionTestTask.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.DAL.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        // тут нету ни одной подписки, т.к. наше приложение в данный момент этого не требует
        // однако, я считаю верным заложить в фундамент потенциал к расширению функционала api
    }
}

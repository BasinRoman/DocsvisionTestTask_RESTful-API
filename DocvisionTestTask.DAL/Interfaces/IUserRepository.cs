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
        Task<User> GetUserByFNameLName(string FnameLname);
    }
}

﻿using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        IBaseResponse<IEnumerable<User>> GetAllUsers();
        Task<IBaseResponse<User>> GetUserByFNameLame(string FNameLName);
    }
}

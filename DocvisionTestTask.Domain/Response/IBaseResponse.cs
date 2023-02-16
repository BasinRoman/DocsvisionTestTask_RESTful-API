using DocvisionTestTask.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocvisionTestTask.Domain.Response
{
    public interface IBaseResponse<T>
    {
        string Description { get; }
        StatusCode statusCode { get; }
        T Data { get; }
    }
}

using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Response;

namespace Business.Interfaces
{
    public interface IUserService
    {
        IBaseResponse<IEnumerable<User>> GetAllUsers();
        Task<IBaseResponse<User>> GetUserByFNameLame(string FNameLName);
    }
}

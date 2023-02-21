using DocvisionTestTask.Domain.Entity;

namespace DocvisionTestTask.DAL.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User> GetUserByFNameLName(string FnameLname);
    }
}

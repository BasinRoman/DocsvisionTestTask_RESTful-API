using DocvisionTestTask.Domain.Model;
using DocvisionTestTask.Domain.Response;

namespace Business.Interfaces
{
    public interface IProfileService
    {
        IBaseResponse<List<ProfileModel>> GetAllProfiles();
    }
}

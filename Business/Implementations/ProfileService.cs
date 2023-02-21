using Business.Interfaces;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using DocvisionTestTask.Domain.Response;


namespace Business.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public IBaseResponse<List<ProfileModel>> GetAllProfiles()
        {
            var baseResponse = new BaseResponse<List<ProfileModel>>();
            try
            {
                var ProfileCollection = _profileRepository.Select();
                List<ProfileModel> result = new List<ProfileModel>();
                foreach (var Profile in ProfileCollection)
                {
                    result.Add(new ProfileModel {
                        firstName = Profile.firstName,
                        lastName = Profile.lastName,
                        Id= Profile.userId,
                    });
                }
                baseResponse.Data = result;
                baseResponse.statusCode = StatusCode.ok;
                baseResponse.Description = "A try to get all profiles: successful";
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<List<ProfileModel>>()
                {
                    Description = exception.Message,
                    statusCode = StatusCode.internalServiceError
                };
            }
        }
    }
}

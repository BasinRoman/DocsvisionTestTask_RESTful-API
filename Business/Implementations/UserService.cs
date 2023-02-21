using Business.Interfaces;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Response;

namespace Business.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IBaseResponse<IEnumerable<User>> GetAllUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var UserCollection = _userRepository.Select();
                baseResponse.Data = UserCollection;

                baseResponse.statusCode = StatusCode.ok;
                baseResponse.Description = "Попытка обращения к базу: успешно";
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Description = exception.Message,
                    statusCode = StatusCode.internalServiceError
                };
            }
        }

        public  async Task<IBaseResponse<User>> GetUserByFNameLame(string FNameLName)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var User = await _userRepository.GetUserByFNameLName(FNameLName);
                baseResponse.Data = User;
                baseResponse.statusCode = StatusCode.ok;
                baseResponse.Description = "Получатель найден.\n";
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<User>()
                {
                    Description = $"Не удалось найти получателя по причине: {exception.Message}\nПисьмо было отправлено на общий почтовый ящик.\n",
                    statusCode = StatusCode.internalServiceError
                };
            }
        }
    }
}

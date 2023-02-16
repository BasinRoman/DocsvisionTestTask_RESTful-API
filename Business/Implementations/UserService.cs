using Business.Interfaces;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IBaseResponse<IEnumerable<User>>> GetAllUsers()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var UserCollection = await _userRepository.Select();
                baseResponse.Data = UserCollection;
                baseResponse.statusCode = StatusCode.ok;
                baseResponse.Description = "A try to get all users: succesful";
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Description = exception.Message,
                    statusCode = StatusCode.InternalServiceError
                };
            }
        }
    }
}

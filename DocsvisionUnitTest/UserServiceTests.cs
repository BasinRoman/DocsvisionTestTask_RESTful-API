using Azure.Core;
using Business.Implementations;
using Business.Interfaces;
using DocvisionTestTask.Controllers;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Entity;
using DocvisionTestTask.Domain.Model;
using DocvisionTestTask.Domain.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Moq;


namespace DocsvisionUnitTest
{
    public class UserServiceTest
    {
        [Fact]
        public void GetAllUsers_NotNull()
        {
            // вводные данные => не возвращает пустой null baseResponse
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.Select()).Returns(new List<User>());
            // Act
            IBaseResponse<IEnumerable<User>> result = service.GetAllUsers();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllUsers_IsType()
        {
            // вводные данные = > возвращаемый тип соответствует
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.Select()).Returns(new List<User>());
            // Act
            IBaseResponse<IEnumerable<User>> result = service.GetAllUsers();
            
            // Assert
            Assert.IsAssignableFrom<IBaseResponse<IEnumerable<User>>>(result);
        }

        [Fact]
        public void GetAllUsers_NoData()
        {
            // не получили данные = > Exception exception + StatusCode.internalServiceError
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.Select()).Returns<IEnumerable<User>>(null);

            // Act
            IBaseResponse<IEnumerable<User>> result = service.GetAllUsers();

            // Assert
            Assert.True(result.Data.IsNullOrEmpty());
        }

        [Fact]
        public void GetAllUsers_ExceptionInGetUserByFNameLName()
        {
            // не получили данные = > не падает в ошибку, возвращает нужный baseResponse
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.Select()).Throws<SystemException>();

            // Act
            IBaseResponse<IEnumerable<User>> result = service.GetAllUsers();

            // Assert
            Assert.Equal(StatusCode.internalServiceError, result.statusCode);
        }

        [Fact]
        public void GetUserByFNameLame_AnyData()
        {
            // вводные данные => не возвращает пустой null baseResponse
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.GetUserByFNameLName(It.IsAny<string>())).ReturnsAsync(new User { });

            // Act
            IBaseResponse<IEnumerable<User>> result = service.GetAllUsers();

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetUserByFNameLame_NotNull()
        {
            // вводные данные корректны  => не возвращает пустой null baseResponse
            // Arrange
            string FnameLname = "123 1322";
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.GetUserByFNameLName(It.IsAny<string>())).ReturnsAsync(new User { });

            // Act
            IBaseResponse<User> result = await service.GetUserByFNameLame(FnameLname);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetUserByFNameLame_IsType()
        {
            // вводные данные => возвращаемый тип соответствует
            // Arrange
            string FnameLname = "123 1322";
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.GetUserByFNameLName(It.IsAny<string>())).ReturnsAsync(new User { });

            // Act
            IBaseResponse<User> result = await service.GetUserByFNameLame(FnameLname);

            // Assert
            Assert.IsAssignableFrom<IBaseResponse<User>>(result);
        }

        [Fact]
        public async Task GetUserByFNameLame_SingleWrong()
        {
            // вводные данные => не падает в ошибку, возвращает нужный baseResponse
            // Arrange
            string FnameLname = "123 1322";
            var mockRepository = new Mock<IUserRepository>();
            var service = new UserService(mockRepository.Object);
            mockRepository.Setup(x => x.GetUserByFNameLName(It.IsAny<string>())).Throws<SystemException>();

            // Act
            IBaseResponse<User> result = await service.GetUserByFNameLame(FnameLname);

            // Assert
            Assert.Equal(StatusCode.internalServiceError, result.statusCode);
        }
    }
}

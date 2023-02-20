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
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DocsvisionUnitTest
{
    
    public class EmailServiceTests
    {
        [Fact]
        public async Task CreateNewInBox_NotNull()
        {
            // вводные данные => не возвращает пустой null baseResponse
            // Arrange
            var newEmail = new EmailModel
            {
                emailDate = DateTime.MinValue,
                emailFrom = "123",
                emailTo = "321",
                emailBody = "test",
                emailSubject = "test",
            };

            var mockRepository = new Mock<IInBoxRepository>();
            
            var mockService = new Mock<IUserService>();

            var service = new EmailService(mockRepository.Object, mockService.Object);

            // Act;
            IBaseResponse<inBox> result = service.CreateNewInBox(newEmail).Result;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateNewInBox_IsType()
        {
            // вводные данные = > возвращаемый тип соответствует
            // Arrange
            var newEmail = new EmailModel
            {
                emailDate = DateTime.MinValue,
                emailFrom = "123",
                emailTo = "321",
                emailBody = "test",
                emailSubject = "test",
            };

            var mockRepository = new Mock<IInBoxRepository>();

            var mockService = new Mock<IUserService>();

            var service = new EmailService(mockRepository.Object, mockService.Object);

            // Act;
            IBaseResponse<inBox> result = service.CreateNewInBox(newEmail).Result;

            // Assert
            Assert.IsType<BaseResponse<inBox>>(result);
        }

        [Fact]
        public async Task CreateNewInBox_NonExistingUser()
        {
            // Пользователь не найден => статус код = ошибка, userId = 1. 
            // Arrange

            var newEmail = new EmailModel
            {
                emailDate = DateTime.MinValue,
                emailFrom = "123",
                emailTo = "321",
                emailBody = "test",
                emailSubject = "test",
            };
            IBaseResponse<User> _userId = null;

            var mockRepository = new Mock<IInBoxRepository>();
            var mockService = new Mock<IUserService>();
            mockService.Setup(x => x.GetUserByFNameLame(newEmail.emailTo)).ReturnsAsync(new BaseResponse<User>() { statusCode = StatusCode.internalServiceError});
            var service = new EmailService(mockRepository.Object, mockService.Object);
            
            // Act;
            IBaseResponse<inBox> result = service.CreateNewInBox(newEmail).Result;

            // Assert
            Assert.Equal(StatusCode.internalServiceError, result.statusCode);
            Assert.Equal(1, result.Data.userId);

        }

        [Fact]
        public async Task CreateNewInBox_NullData()
        {
            // Null в полях =>  internalServiceError + Description
            // Arrange
            var newEmail = new EmailModel
            {
                emailDate = DateTime.MinValue,
                emailFrom = null,
                emailTo = null,
                emailBody = null,
                emailSubject = null,
            };

            var mockRepository = new Mock<IInBoxRepository>();
            var mockService = new Mock<IUserService>();
            mockService.Setup(x => x.GetUserByFNameLame(newEmail.emailTo)).ReturnsAsync(new BaseResponse<User>() { statusCode = StatusCode.internalServiceError });
            var service = new EmailService(mockRepository.Object, mockService.Object);

            // Act;
            IBaseResponse<inBox> result = service.CreateNewInBox(newEmail).Result;

            // Assert
            Assert.Equal(result.statusCode, StatusCode.internalServiceError);
            Assert.Equal(result.Description,  $"Не удалось отправить письмо адресованное пользователю [ {newEmail.emailTo} ].\n");
        }

        [Fact]
        public async Task CreateNewInBox_CorrectUser()
        {
            // Null в полях =>  internalServiceError + Description
            // Arrange
            var newEmail = new EmailModel
            {
                emailDate = DateTime.MinValue,
                emailFrom = "123",
                emailTo = "1",
                emailBody = "test",
                emailSubject = "test",
            };
            var newInbox = new inBox
            {
                userId = 1,
                emailDate = newEmail.emailDate,
                emailFrom = newEmail.emailFrom,
                emailTo = newEmail.emailTo,
                emailBody = newEmail.emailBody,
                emailSubject = newEmail.emailSubject,
            };

            var mockRepository = new Mock<IInBoxRepository>();
            var mockService = new Mock<IUserService>();
            mockService.Setup(x => x.GetUserByFNameLame(newEmail.emailTo))
                .ReturnsAsync(new BaseResponse<User>() { statusCode = StatusCode.internalServiceError });
            mockRepository.Setup(x => x.Create(It.IsAny<inBox>())).ReturnsAsync(true);
            var service = new EmailService(mockRepository.Object, mockService.Object);

            // Act;
            IBaseResponse<inBox> result = service.CreateNewInBox(newEmail).Result;

            // Assert
            Assert.Equal(result.statusCode, StatusCode.ok);
            Assert.Equal(result.Description, $"Письмо адресованное пользователю [ {newInbox.emailTo} ] успешно доставлено.\n");
        }



    }
}

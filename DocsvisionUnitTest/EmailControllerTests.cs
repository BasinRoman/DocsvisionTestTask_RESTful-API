using Business.Implementations;
using Business.Interfaces;
using DocvisionTestTask.Controllers;
using DocvisionTestTask.DAL.Interfaces;
using DocvisionTestTask.Domain.Model;
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
    
    public class EmailControllerTests
    {
        [Fact]
        public void CreateEmail_EmptyData_NotNull()
        {
            // Arrange
            var mock = new Mock<IEmailService>();
            EmailModel email = new EmailModel();
            EmailController emailController = new EmailController(mock.Object);

            // Act;
            Task<ActionResult<EmailModel>> result = emailController.CreateEmail(email);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateEmail_NullData_NotNull()
        {
            // Arrange
            var mock = new Mock<IEmailService>();
            EmailModel email = null;
            EmailController emailController = new EmailController(mock.Object);

            // Act;
            Task<ActionResult<EmailModel>> result = emailController.CreateEmail(email);

            // Assert
            Assert.NotNull(result);
        }

        //[Fact]
        //public async Task CreateEmail_WrongReceiver_NotBadReq()
        //{
        //    // Arrange
        //    var expectedResult = "\"Письмо адресованное пользователю [ Вечный Восторг ] успешно доставлено.\\n" +
        //        "Не удалось найти получателя по причине:  [Адресат с фамилией Вечный и именем Восторг не найден] \\" +
        //        "nПисьмо было отправлено на общий почтовый ящик.\\n\"";
        //    var mock = new Mock<IEmailService>();
        //    var mock1 = new Mock<IInBoxRepository>(); //????
        //    EmailModel email = new EmailModel()
        //    {
        //        emailBody = "123",
        //        emailDate = DateTime.Now,
        //        emailFrom = "321",
        //        emailSubject = "123",
        //        emailTo = "Вечный Восторг"
        //    };
        //    EmailController emailController = new EmailController(mock.Object);

        //    // Act;
        //    ActionResult<EmailModel> result = await emailController.CreateEmail(email);
            
        //    // Assert
        //    Assert.IsType<OkObjectResult>(result.Result);
        //    //Assert.Equal(expectedResult, result);
        //}
    }
}

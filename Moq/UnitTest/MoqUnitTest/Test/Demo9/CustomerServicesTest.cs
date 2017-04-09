using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqUnitTest.Code.Demo09;
using Moq;

namespace MoqUnitTest.Test.Demo9
{
    [TestClass]
    public class CustomerServicesTest
    {
        //verify that specific parameter values are passed to the mock object
        [TestMethod]
        public void The_Local_Time_Zone_Should_Be_Set()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            var customerService = new CustomerService(mockCustomerRepository.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockCustomerRepository.VerifySet(x => x.LocalTimeZone = It.IsAny<string>());
        }
    }
}
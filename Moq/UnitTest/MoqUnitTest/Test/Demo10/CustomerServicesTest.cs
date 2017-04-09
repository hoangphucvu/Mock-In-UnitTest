using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqUnitTest.Code.Demo10;
using Moq;

namespace MoqUnitTest.Test.Demo10
{
    [TestClass]
    public class CustomerServicesTest
    {
        //verify that specific parameter values are passed to the mock object
        [TestMethod]
        public void The_WorkstationCreatedOn_Shoud_Be_Used()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockApplicationSettings.Setup(x => x.WorkstationId).Returns(123);

            var customerService = new CustomerService(
                mockCustomerRepository.Object,
                mockApplicationSettings.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockApplicationSettings.VerifyGet(x => x.WorkstationId);
        }
    }
}
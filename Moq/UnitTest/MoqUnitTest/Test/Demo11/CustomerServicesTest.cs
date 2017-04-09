using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqUnitTest.Code.Demo11;
using Moq;

namespace MoqUnitTest.Test.Demo11
{
    [TestClass]
    public class CustomerServicesTest
    {
        //verify that specific parameter values are passed to the mock object
        [TestMethod]
        public void The_Workstationid_Shoud_Be_Retrieved()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockApplicationSettings = new Mock<IApplicationSettings>();

            mockApplicationSettings.Setup(x => x.SystemConfiguration.AuditingInformation.WorkstationId).Returns(123);

            var customerService = new CustomerService(mockCustomerRepository.Object, mockApplicationSettings.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockApplicationSettings.VerifyGet(x => x.SystemConfiguration.AuditingInformation.WorkstationId);
        }
    }
}
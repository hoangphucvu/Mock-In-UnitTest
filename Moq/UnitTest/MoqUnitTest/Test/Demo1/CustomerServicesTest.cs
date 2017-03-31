using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqUnitTest.Code.Demo01;


namespace MoqUnitTest.Test.Demo1
{
    [TestClass]
    public class CustomerServicesTest
    {
        [TestMethod]
        public void The_Repository_Save_Should_Be_Call()
        {
            //Arrange
            var mockRepository = new Mock<ICustomerRepository>();

            //the save method should receive any type customer to pass in
            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));

            var customerService = new CustomerService(mockRepository.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            //assume that all method will be call
            mockRepository.VerifyAll();
        }
    }
}
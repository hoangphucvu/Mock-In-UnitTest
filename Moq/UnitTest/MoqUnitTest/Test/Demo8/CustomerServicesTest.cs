using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqUnitTest.Code.Demo08;

namespace MoqUnitTest.Test.Demo8
{
    [TestClass]
    public class CustomerServicesTest
    {
        //verify that specific parameter values are passed to the mock object
        [TestMethod]
        [ExpectedException(typeof(CustomerCreationException))]
        public void An_Exception_Should_Be_Raised()
        {
            //Arrange


            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockCustomerAddressFactory = new Mock<ICustomerAddressFactory>();

            mockCustomerAddressFactory
                .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
                .Throws<InvalidCustomerAddressException>();

            var customerService = new CustomerService(mockCustomerRepository.Object, mockCustomerAddressFactory.Object);
            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert


        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqUnitTest.Code.Demo04;

namespace MoqUnitTest.Test.Demo4
{
    [TestClass]
    public class CustomerServicesTest
    {
        [TestMethod]
        public void The_Customer_Should_Be_Persisted()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockMailingAddressFactory = new Mock<IMailingAddressFactory>();

            var mailingAddress = new MailingAddress { Country = "Canada" };

            mockMailingAddressFactory
                .Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress))
                .Returns(true);

            var customerService = new CustomerService(mockCustomerRepository.Object, mockMailingAddressFactory.Object);

            //Act
            customerService.Create(new CustomerToCreateDto());

            //Assert
            mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));

        }

    }
}
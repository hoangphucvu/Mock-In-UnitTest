using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqUnitTest.Code.Demo03;

namespace MoqUnitTest.Test.Demo3
{
    [TestClass]
    public class CustomerServicesTest
    {

        //this shows how setting the return value will change the execution flow
        [TestMethod]
        [ExpectedException(typeof(InvalidCustomerMailingAddressException))]
        public void An_exception_should_be_thrown_if_the_address_is_not_created()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto
            { FirstName = "Bob", LastName = "Builder" };
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder
               .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
               .Returns(() => null);

            var customerService = new CustomerService(
                mockAddressBuilder.Object,
                mockCustomerRepository.Object);

            //Act
            customerService.Create(customerToCreateDto);

            //Assert
        }

        [TestMethod]
        public void the_customer_should_be_saved_if_the_address_was_created()
        {
            //Arrange
            var customerToCreateDto = new CustomerToCreateDto { FirstName = "Bob", LastName = "Builder" };
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            mockAddressBuilder
               .Setup(x => x.From(It.IsAny<CustomerToCreateDto>()))
               .Returns(() => new Address());

            var customerService = new CustomerService(mockAddressBuilder.Object, mockCustomerRepository.Object);

            //Act
            customerService.Create(customerToCreateDto);

            //Assert
            mockCustomerRepository.Verify(y => y.Save(It.IsAny<Customer>()));
        }

    }
}
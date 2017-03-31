using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqUnitTest.Code.Demo05;


namespace MoqUnitTest.Test.Demo5
{
    [TestClass]
    public class CustomerServicesTest
    {
        [TestMethod]
        public void The_Customer_Should_Be_Persisted()
        {
            //Arrange
            var listOfCustomerToCreate = new List<CustomerToCreateDto>
            {
                new CustomerToCreateDto(),
                new CustomerToCreateDto()
            };
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockIdFactory = new Mock<IIdFactory>();

            var i = 1;
            mockIdFactory
                .Setup(x => x.Create())
                .Returns(() => i)
                .Callback(() => i++);


            var customerService = new CustomerService(mockCustomerRepository.Object, mockIdFactory.Object);

            //Act
            customerService.Create(listOfCustomerToCreate);

            //Assert
            mockIdFactory.Verify(x => x.Create(), Times.AtLeastOnce());
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqUnitTest.Code.Demo07;

namespace MoqUnitTest.Test.Demo7
{
    [TestClass]
    public class CustomerServicesTest
    {
        //verify that specific parameter values are passed to the mock object
        [TestMethod]
        public void A_Full_Name_Should_Be_Created_From_First_And_Last_Name()
        {
            //Arrange
            var customer = new CustomerToCreateDto
            {
                DesiredStatus = CustomerStatus.Platinum,
                FirstName = "Tony",
                LastName = "Hudson"
            };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockCustomerStatusFactory = new Mock<ICustomerStatusFactory>();

            mockCustomerStatusFactory
                .Setup(x => x.CreateFrom(It.Is<CustomerToCreateDto>
                (y => y.DesiredStatus == CustomerStatus.Platinum)))
                .Returns(CustomerStatus.Platinum);

            var customerService = new CustomerService(mockCustomerRepository.Object, mockCustomerStatusFactory.Object);
            //Act
            customerService.Create(customer);

            //Assert
            mockCustomerRepository.Verify(x => x.SaveSpecial(It.IsAny<Customer>()));

        }
    }
}
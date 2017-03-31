using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqUnitTest.Code.Demo06;

namespace MoqUnitTest.Test.Demo6
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
                FirstName = "Tony",
                LastName = "Hudson"
            };
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockCustomerFullName = new Mock<ICustomerFullNameBuilder>();



            mockCustomerFullName.Setup(x => x.From(It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());

            var customerService = new CustomerService(mockCustomerRepository.Object, mockCustomerFullName.Object);
            //Act
            customerService.Create(customer);

            //Assert
            mockCustomerFullName.Verify(x => x.From(
                It.Is<string>(fn => fn.Equals(customer.FirstName, StringComparison.InvariantCultureIgnoreCase)),
                It.Is<string>(fn => fn.Equals(customer.LastName, StringComparison.InvariantCultureIgnoreCase))));
            //mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));

        }
    }
}
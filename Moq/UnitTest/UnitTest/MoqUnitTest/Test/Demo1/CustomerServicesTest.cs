using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MoqUnitTest.Code.Demo01;
using NUnit.Framework;

namespace MoqUnitTest.Test.Demo1
{
    [TestFixture]
    public class CustomerServicesTest
    {
        [Test]
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
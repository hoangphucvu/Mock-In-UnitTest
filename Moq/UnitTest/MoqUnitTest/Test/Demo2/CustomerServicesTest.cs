using Moq;
using MoqUnitTest.Code.Demo02;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoqUnitTest.Test.Demo2
{
    [TestClass]
    public class CustomerServicesTest
    {
        //shows how to verify that a method was called an explicit number of times
        [TestMethod]
        public void The_Customer_Repository_Should_Be_Called_Once_Per_Customer()
        {
            //Arrange
            var listOfCustomerDtos = new List<CustomerToCreateDto>
                    {
                        new CustomerToCreateDto
                            {
                                FirstName = "Sam", LastName = "Sampson"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Bob", LastName = "Builder"
                            },
                        new CustomerToCreateDto
                            {
                                FirstName = "Doug", LastName = "Digger"
                            }
                    };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            //system under test
            var customerServices = new CustomerService(mockCustomerRepository.Object);

            //Act
            customerServices.Create(listOfCustomerDtos);

            //Assert
            mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()),
                Times.Exactly(listOfCustomerDtos.Count));
        }
    }
}
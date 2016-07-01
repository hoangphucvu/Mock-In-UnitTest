using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMS.UnitTestTraining.Entities;
using KMS.UnitTestTraining.Repositories;
using Moq;
using KMS.UnitTestTraining.Services;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    /// <summary>
    /// Summary description for OrderServiceTest
    /// </summary>
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void AddNewOrder_ShouldAddNewOrderCorrectly_WhenCalledWithValidParameters()
        {
            //Arrange 
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();


            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            Order order = new Order(1, 1, "Address");
            OrderItem orderItem1 = new OrderItem(1, 1, 1, 5);
            OrderItem orderItem2 = new OrderItem(2, 1, 2, 3);

            var products = new List<Product>()
            {
                new Product(1, "Product A", 40M),
                new Product(2, "Product B", 20M)
            };

            mockOrderRepository.Setup(x => x.Insert(order));
            mockOrderItemRepository.Setup(x => x.Insert(orderItem1));
            mockOrderItemRepository.Setup(x => x.Insert(orderItem2));
            // Act
            orderService.AddNewOrder(products);

            //Assert
            
            mockOrderRepository.Verify(x => x.Insert(order), Times.Once);
            mockOrderItemRepository.Verify(x => x.Insert(orderItem1), Times.Once);
            mockOrderItemRepository.Verify(x => x.Insert(orderItem1), Times.Once);
        }
    }
}

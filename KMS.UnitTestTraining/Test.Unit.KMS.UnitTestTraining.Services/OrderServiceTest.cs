using KMS.UnitTestTraining.Entities;
using KMS.UnitTestTraining.Repositories;
using KMS.UnitTestTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    /// <summary>
    /// Summary description for OrderServiceTest
    /// </summary>
    [TestClass]
    public class OrderServiceTest
    {
        #region Add New Order Test

        //[TestMethod]
        //public void AddNewOrder_ShouldAddNewOrderCorrectly_WhenCalledWithValidParameters()
        //{
        //    //Arrange
        //    Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
        //    Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
        //    Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

        //    var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

        //    Order order = new Order(1, 1, "Address");
        //    OrderItem orderItem1 = new OrderItem(1, 1, 1, 5);
        //    OrderItem orderItem2 = new OrderItem(2, 1, 2, 3);

        //    var products = new List<Product>()
        //    {
        //        new Product(1, "Product A", 40M),
        //        new Product(2, "Product B", 20M)
        //    };

        //    mockOrderRepository.Setup(x => x.Insert(order));
        //    mockOrderItemRepository.Setup(x => x.Insert(orderItem1));
        //    mockOrderItemRepository.Setup(x => x.Insert(orderItem2));
        //    // Act
        //    orderService.AddNewOrder(products);

        //    //Assert

        //    mockOrderRepository.Verify(x => x.Insert(order), Times.Once);
        //    mockOrderItemRepository.Verify(x => x.Insert(orderItem1), Times.Once);
        //    mockOrderItemRepository.Verify(x => x.Insert(orderItem1), Times.Once);
        //}

        #endregion Add New Order Test

        #region Get All Product By OrderID

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAllProductByOrderID_ShouldThrowException_WithInvalidParameters()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            //Act
            var result = orderService.GetAllProductByOrderId(0);

            //Assert
        }

        [TestMethod]
        public void GetAllProductByOrderID_Should_Return_One_Product()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product1 = new Product(1, "Chair", 20);
            var product2 = new Product(2, "Desk", 15);
            var orderItem1 = new OrderItem(1, 1, 1, 1);
            var orderItem2 = new OrderItem(2, 2, 2, 1);
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product1);
            var result = orderService.GetAllProductByOrderId(1);

            //Assert
            mockOrderItemRepository.Verify(x => x.GetAll(), Times.Once);
            mockProductRepository.Verify(x => x.GetProductById(1), Times.AtLeastOnce);

            Assert.IsNotNull(result);
            Assert.AreEqual("Chair", product1.Name);
        }

        [TestMethod]
        public void GetAllProductByOrderID_Should_Return_EmptyList_WhenCallWithOrder_Has_No_Product_Item()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product1 = new Product(1, "Chair", 20);
            var product2 = new Product(2, "Desk", 15);
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            //Act
            mockOrderItemRepository.Verify(x => x.GetAll(), Times.Never);
            mockProductRepository.Verify(x => x.GetProductById(1), Times.Never);
            var result = orderService.GetAllProductByOrderId(1);

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        #endregion Get All Product By OrderID

        #region Update Product Quantity with OrderID

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateProductQuantity_Should_ThrowException_With_Invalid_OrderId()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var orderItem1 = new OrderItem(1, 1, 1, 1);
            var orderItem2 = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(0, 1, 4);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateProductQuantity_Should_ThrowException_With_Invalid_ProductId()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var orderItem1 = new OrderItem(1, 1, 1, 1);
            var orderItem2 = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 0, 4);

            //Assert
        }

        [TestMethod]
        public void UpdateProductQuantity_Should_Return_Quantity_Equal_0()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var orderItem1 = new OrderItem(1, 1, 1, 1);
            var orderItem2 = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 1, 0);

            //Assert
            Assert.AreEqual(0, orderItem1.Quantity);
        }

        [TestMethod]
        public void UpdateProductQuantity_Should_Not_Change_When_Update_With_Unchange_Value()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var orderItem1 = new OrderItem(1, 1, 1, 1);
            var orderItem2 = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 1, 1);

            //Assert
            Assert.AreEqual(1, orderItem1.Quantity);
        }

        [TestMethod]
        public void UpdateProductQuantity_Should_Return_New_Quantity_With_Valid_Quantity_Number()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var orderItem1 = new OrderItem(1, 1, 1, 1);
            var orderItem2 = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 1, 4);

            //Assert
            Assert.AreEqual(4, orderItem1.Quantity);
        }

        #endregion Update Product Quantity with OrderID

        #region Calculate Final price

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateFinalPrice_Should_Throw_Exception_When_OrderId_Invalid()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product1 = new Product(1, "Chair", 60);
            var product2 = new Product(2, "Desk", 20);
            var orderItem1 = new OrderItem(1, 1, 1, 2);
            var orderItem2 = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product1);
            mockProductRepository.Setup(x => x.GetProductById(2)).Returns(product2);
            var total = orderService.CalculateFinalPrice(0);

            //Assert
        }

        [TestMethod]
        public void CalculateFinalPrice_Return_Corret_Result()
        {
            //Arrange
            Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();
            Mock<IOrderItemRepository> mockOrderItemRepository = new Mock<IOrderItemRepository>();
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product1 = new Product(1, "Chair", 60);
            var product2 = new Product(2, "Desk", 20);
            var orderItem1 = new OrderItem(1, 1, 1, 2);
            var orderItem2 = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(orderItem1);
            orderItemList.Add(orderItem2);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product1);
            mockProductRepository.Setup(x => x.GetProductById(2)).Returns(product2);
            var total = orderService.CalculateFinalPrice(1);

            //Assert
            Assert.AreEqual(126, total);
        }

        #endregion Calculate Final price
    }
}
using KMS.UnitTestTraining.Entities;
using KMS.UnitTestTraining.Repositories;
using KMS.UnitTestTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    /// <summary>
    /// Summary description for OrderServiceTest
    /// </summary>
    [TestClass]
    public class OrderServiceTest
    {
        private Mock<IOrderRepository> mockOrderRepository;
        private Mock<IOrderItemRepository> mockOrderItemRepository;
        private Mock<IProductRepository> mockProductRepository;

        [TestInitialize]
        public void CreateMock()
        {
            mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderItemRepository = new Mock<IOrderItemRepository>();
            mockProductRepository = new Mock<IProductRepository>();
        }

        #region Constructor Test

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitConstructor_Should_Throw_Exception_WhenCalledWithValid_MockOrderRepo()
        {
            var orderService = new OrderService(null, mockOrderItemRepository.Object, mockProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitConstructor_Should_Throw_Exception_WhenCalledWithValid_MockOrderItemRepo()
        {
            var orderService = new OrderService(mockOrderRepository.Object, null, mockProductRepository.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitConstructor_Should_Throw_Exception_WhenCalledWithValid_MockProductRepo()
        {
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitConstructor_Should_Throw_Exception_WhenCalledWithValid_MockRepo()
        {
            var orderService = new OrderService(null, null, null);
        }

        #endregion Constructor Test

        #region Add New Order Test

        [TestMethod]
        public void AddNewOrder_ShouldAddNewOrderCorrectly_WhenCalledWithValidParameters()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            var products = new List<Product>()
            {
                new Product(1, "Product A", 40)
            };
            OrderItem orderItem = new OrderItem(1, 1, 1, 1);
            mockOrderItemRepository.Setup(x => x.Insert(orderItem));

            // Act
            orderService.AddNewOrder(products);

            //Assert

            mockOrderItemRepository.Verify(x => x.Insert(It.Is<OrderItem>(
            item => item.OrderId == orderItem.OrderId && item.OrderItemId == orderItem.OrderItemId
            && item.ProductId == orderItem.ProductId && item.Quantity == orderItem.Quantity)), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewOrder_ShouldThrowException_WhenCalledWithInValidParameters()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            OrderItem firstOrderItem = new OrderItem(1, 1, 1, 5);
            OrderItem secondOrderItem = new OrderItem(2, 1, 2, 3);

            var products = new List<Product>() { };

            mockOrderItemRepository.Setup(x => x.Insert(firstOrderItem));
            mockOrderItemRepository.Setup(x => x.Insert(secondOrderItem));

            // Act
            orderService.AddNewOrder(products);

            //Assert
            mockOrderItemRepository.Verify(x => x.Insert(firstOrderItem), Times.Once);
            mockOrderItemRepository.Verify(x => x.Insert(secondOrderItem), Times.Once);
        }

        #endregion Add New Order Test

        #region Get All Product By OrderID

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAllProductByOrderID_ShouldThrowException_WithInvalidParameters()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            //Act
            var result = orderService.GetAllProductByOrderId(0);

            //Assert
        }

        [TestMethod]
        public void GetAllProductByOrderID_Should_Return_One_Product()
        {
            //Arrange
            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var orderItem = new OrderItem(1, 1, 1, 1);
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            orderItemList.Add(orderItem);

            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            //Act

            var result = orderService.GetAllProductByOrderId(1);

            //Assert
            mockOrderItemRepository.Verify(x => x.GetAll(), Times.Once);
            mockProductRepository.Verify(x => x.GetProductById(1), Times.AtLeastOnce);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Chair", product.Name);
        }

        [TestMethod]
        public void GetAllProductByOrderID_Should_Return_Two_Product()
        {
            //Arrange
            List<OrderItem> orderItemList = new List<OrderItem>();
            var firstProduct = new Product(1, "Chair", 20);
            var secondProduct = new Product(2, "Desk", 15);
            var firstOrderItem = new OrderItem(1, 1, 1, 1);
            var secondOrderItem = new OrderItem(2, 1, 2, 1);
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            orderItemList.Add(firstOrderItem);
            orderItemList.Add(secondOrderItem);

            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(firstProduct);
            //Act

            var result = orderService.GetAllProductByOrderId(1);

            //Assert
            mockOrderItemRepository.Verify(x => x.GetAll(), Times.Once);
            mockProductRepository.Verify(x => x.GetProductById(1), Times.AtLeastOnce);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Chair", firstProduct.Name);
            Assert.AreEqual("Desk", secondProduct.Name);
        }

        [TestMethod]
        public void GetAllProductByOrderID_Should_Return_EmptyList_WhenCallWithOrder_Has_No_Product_Item()
        {
            //Arrange
            List<OrderItem> orderItemList = new List<OrderItem>();
            var firstProduct = new Product(1, "Chair", 20);
            var secondProduct = new Product(2, "Desk", 15);
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
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            //Act
            orderService.UpdateProductQuantity(0, 1, 4);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateProductQuantity_Should_ThrowException_With_Invalid_ProductId()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            //Act
            orderService.UpdateProductQuantity(1, 0, 4);

            //Assert
        }

        [TestMethod]
        public void UpdateProductQuantity_Should_Return_Quantity_Equal_0()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var firstOrderItem = new OrderItem(1, 1, 1, 1);
            var secondOrderItem = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(firstOrderItem);
            orderItemList.Add(secondOrderItem);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 1, 0);

            //Assert
            Assert.AreEqual(0, firstOrderItem.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateProductQuantity_Should_Throw_Exception_When_Quantity_Is_Smaller_Than_0()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var firstOrderItem = new OrderItem(1, 1, 1, 1);
            var secondOrderItem = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(firstOrderItem);
            orderItemList.Add(secondOrderItem);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 1, -50);

            //Assert
        }

        [TestMethod]
        public void UpdateProductQuantity_Should_Not_Change_When_Update_With_Unchange_Value()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var firstOrderItem = new OrderItem(1, 1, 1, 1);
            var secondOrderItem = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(firstOrderItem);
            orderItemList.Add(secondOrderItem);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 1, 1);

            //Assert
            Assert.AreEqual(1, firstOrderItem.Quantity);
        }

        [TestMethod]
        public void UpdateProductQuantity_Should_Return_New_Quantity_With_Valid_Quantity_Number()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);
            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 20);
            var firstOrderItem = new OrderItem(1, 1, 1, 1);
            var secondOrderItem = new OrderItem(2, 2, 2, 1);

            orderItemList.Add(firstOrderItem);
            orderItemList.Add(secondOrderItem);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            orderService.UpdateProductQuantity(1, 1, 4);

            //Assert
            Assert.AreEqual(4, firstOrderItem.Quantity);
        }

        #endregion Update Product Quantity with OrderID

        #region Calculate Final price

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateFinalPrice_Should_Throw_Exception_When_OrderId_Invalid()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            //Act
            var total = orderService.CalculateFinalPrice(0);

            //Assert
        }

        [TestMethod]
        public void CalculateFinalPrice_For_One_Product_Return_Corret_Result()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var product = new Product(1, "Chair", 60);
            var orderItem = new OrderItem(1, 1, 1, 2);

            orderItemList.Add(orderItem);

            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);
            var total = orderService.CalculateFinalPrice(1);

            //Assert
            Assert.AreEqual(126, total);
        }

        [TestMethod]
        public void CalculateFinalPrice_For_Two_Product_Return_Corret_Result()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var firstProduct = new Product(1, "Chair", 60);
            var secondProduct = new Product(2, "Desk", 20);
            var firstOrderItem = new OrderItem(1, 1, 1, 2);
            var secondOrderItem = new OrderItem(2, 1, 2, 2);
            orderItemList.Add(firstOrderItem);
            orderItemList.Add(secondOrderItem);
            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(firstProduct);
            mockProductRepository.Setup(x => x.GetProductById(2)).Returns(secondProduct);
            var total = orderService.CalculateFinalPrice(1);
            //Assert
            Assert.AreEqual(166, total);
        }

        [TestMethod]
        public void CalculateFinalPrice_When_OrderId_Greater_Than_0_But_OrderItemList_Not_Exists()
        {
            //Arrange
            var orderService = new OrderService(mockOrderRepository.Object, mockOrderItemRepository.Object, mockProductRepository.Object);

            List<OrderItem> orderItemList = new List<OrderItem>();
            var firstProduct = new Product(1, "Chair", 60);
            var secondProduct = new Product(2, "Desk", 20);
            var firstOrderItem = new OrderItem(1, 1, 1, 2);
            var secondOrderItem = new OrderItem(2, 2, 2, 1);
            //not add to orderItem list
            //Act
            mockOrderItemRepository.Setup(x => x.GetAll()).Returns(orderItemList);
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(firstProduct);
            mockProductRepository.Setup(x => x.GetProductById(2)).Returns(secondProduct);
            var total = orderService.CalculateFinalPrice(1);

            //Assert
            Assert.AreEqual(0, total);
        }

        #endregion Calculate Final price
    }
}
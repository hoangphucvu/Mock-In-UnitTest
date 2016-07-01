using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMS.UnitTestTraining.Entities;
using Moq;
using KMS.UnitTestTraining.Repositories;
using KMS.UnitTestTraining.Services;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public void GetProductById_Should_Work_Correctly()
        {
            //Arrange
            Product product = new Product(1, "Product A", 10);
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(x => x.GetProductById(1)).Returns(product);

            //Act
            ProductService productService = new ProductService(mockProductRepository.Object);
            var resultProduct = productService.GetProductById(1);

            //Assert
            mockProductRepository.Verify(x => x.GetProductById(1), Times.Once);
            Assert.IsNotNull(resultProduct);
            Assert.AreEqual(product.Id, resultProduct.Id);
            Assert.AreEqual(product.Name, resultProduct.Name);
            Assert.AreEqual(product.Price, resultProduct.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetProductById_Should_Throw_Exception_When_Id_Is_Zero()
        {
            //Arrange
            Product product = new Product(1, "Product A", 10);
            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();

            //Act
            ProductService productService = new ProductService(mockProductRepository.Object);
            var resultProduct = productService.GetProductById(0);

            //Assert
        }
    }
}

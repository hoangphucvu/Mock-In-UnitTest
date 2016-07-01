using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMS.UnitTestTraining.Entities;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    /// <summary>
    /// Check constructor for Product class
    /// </summary>
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Product_Constructor_Test()
        {
            Product product = new Product(1, "Banh mi", 12);
            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("Banh mi", product.Name);
            Assert.AreEqual(12, product.Price);
        }
    }
}

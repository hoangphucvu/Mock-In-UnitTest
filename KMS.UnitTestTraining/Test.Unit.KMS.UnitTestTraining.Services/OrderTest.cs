using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMS.UnitTestTraining.Entities;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    /// <summary>
    /// Check constructor Order class
    /// </summary>
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Order_Constructor_Test()
        {
            Order order = new Order(1,10,"123 Cong Hoa");
            Assert.AreEqual(1, order.OrderId);
            Assert.AreEqual(10, order.CustomerId);
            Assert.AreEqual("123 Cong Hoa", order.ShippingAddress);
        }
    }
}

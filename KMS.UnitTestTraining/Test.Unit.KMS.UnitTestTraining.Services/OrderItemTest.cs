using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KMS.UnitTestTraining.Entities;

namespace Tests.Unit.KMS.UnitTestTraining.Services
{
    /// <summary>
    /// Check constructor OrderItem class
    /// </summary>
    [TestClass]
    public class OrderItemTest
    {
        [TestMethod]
        public void OrderItem_Constructor_Test()
        {
            OrderItem orderItem = new OrderItem(1, 1, 100, 5);
            Assert.AreEqual(1, orderItem.OrderItemId);
            Assert.AreEqual(1, orderItem.OrderId);
            Assert.AreEqual(100, orderItem.ProductId);
            Assert.AreEqual(5, orderItem.Quantity);
        }
    }
}

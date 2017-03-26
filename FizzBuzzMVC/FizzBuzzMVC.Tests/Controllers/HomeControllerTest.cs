using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzMVC;
using FizzBuzzMVC.Controllers;

namespace FizzBuzzMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Given1Return1()
        {
            FizzBuzzController controller = new FizzBuzzController();
            ViewResult result = controller.Index(1) as ViewResult;
            string expected = "1";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void Given3Return12Fizz()
        {
            FizzBuzzController controller = new FizzBuzzController();
            ViewResult result = controller.Index(3) as ViewResult;
            string expected = "1 2 Fizz ";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Given5Return12Fizz4Buzz()
        {
            FizzBuzzController controller = new FizzBuzzController();
            ViewResult result = controller.Index(5) as ViewResult;
            string expected = "1 2 Fizz 4 Buzz ";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Given15ReturnFizzBuzz()
        {
            FizzBuzzController controller = new FizzBuzzController();
            ViewResult result = controller.Index(15) as ViewResult;
            string expected = "1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz ";
            string actual = result.ViewBag.Output;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

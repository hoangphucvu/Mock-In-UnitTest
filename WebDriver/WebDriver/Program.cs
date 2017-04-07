using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace WebDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"E:\Source Code\Study\.Net-UnitTest\WebDriver\WebDriver\Driver\chromedriver.exe");
            driver.Url = "http://google.com";
        }
    }
}

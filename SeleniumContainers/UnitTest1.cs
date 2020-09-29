using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace SeleniumContainers
{
    [TestClass]
    public class UnitTest1
    {       
        [TestMethod]
        public void Chrome_Test()
        {
            var options = new ChromeOptions();
             var _driver = new RemoteWebDriver(new Uri("http://192.168.10.106:4444/wd/hub"), options);
            _driver.Navigate().GoToUrl("https://www.google.com");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _driver.FindElementByName("q").SendKeys("Automation");
            _driver.FindElementByName("btnK").Click();
            Assert.IsTrue(_driver.Title.Equals("Automation - Google Search"));
            _driver.Quit();
        }
    }
}

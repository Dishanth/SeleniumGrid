using System;
using System.Drawing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumGridParallel
{
    [TestFixture]
    [Parallelizable]
    public class UnitTest1
    {
        public string RemoteWebDriverUrl { get; set; }
        IWebDriver _driver;

        [Test]
        public void Chrome_Test()
        {
            Testhelper.CloseDriver("chromedriver");
            RemoteWebDriverUrl = "http://localhost:4444/wd/hub";
            var options = new ChromeOptions();
            _driver = new RemoteWebDriver(new Uri(RemoteWebDriverUrl), options);
            _driver.Navigate().GoToUrl("https://www.google.com");
            _driver.Manage().Window.Size = new Size(950, 1020);
            _driver.Manage().Window.Position = new Point(0, 0);
            _driver.FindElementWithTimeout(By.Name("q"), 5).SendKeys("SeleniumHQ");
            _driver.FindElementWithTimeout(By.Name("btnK"), 5).Click();
            System.Threading.Thread.Sleep(2000);
            Assert.IsTrue(_driver.Title.Equals("SeleniumHQ - Google Search"));
            System.Threading.Thread.Sleep(2000);
            _driver.FindElementWithTimeout(By.XPath("//span[contains(text(),'SeleniumHQ Browser Automation')]"), 5).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElementWithTimeout(By.LinkText("Documentation"), 5).Click();
            System.Threading.Thread.Sleep(2000);
            _driver.FindElementWithTimeout(By.LinkText("Grid"), 5).Click();
            System.Threading.Thread.Sleep(2000);
            var gridelement = _driver.FindElementWithTimeout(By.Id("grid"), 5);
            Assert.AreEqual(gridelement.Text, "Grid", "Does not match Grid headername");
        }


        [TearDown]
        public void Cleanup()
        {
            _driver.Close();
        }
    }
}

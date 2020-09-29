using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumGridParallel
{
    public static class Testhelper
    {
        public static IWebElement FindElementWithTimeout(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            return driver.FindElement(by);
        }
        public static void CloseDriver(string driverName)
        {
            var allProcesses = Process.GetProcessesByName(driverName);

            foreach (var process in allProcesses)
            {
                process.Kill();
            }
        }       
    }
}

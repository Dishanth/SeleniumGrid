using System;
using System.Diagnostics;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace SeleniumGridParallel
{
    [TestFixture]
    public class Basetest
    {
        public string RemoteWebDriverUrl { get; set; }

        [SetUp]
        public void TestInitialize()
        {
            CloseDriver("chromedriver");
            CloseDriver("geckodriver");
            RemoteWebDriverUrl = "http://localhost:4444/wd/hub";
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

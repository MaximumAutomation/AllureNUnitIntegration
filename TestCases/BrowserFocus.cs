using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Threading;
using System.Diagnostics;

namespace SeleniumNUnit.TestCases
{
    public class BrowserFocus
    {
        [Test]
        public void ActivateBrowser()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://amazon.com");
            Thread.Sleep(5000);
            //driver.Manage().Window.Minimize();

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = @"C:\Project\SeleniumNUnit",
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);

            Thread.Sleep(5000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}

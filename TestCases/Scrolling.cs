using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumNUnit.TestCases
{
    public class Scrolling
    {
        [Test]
        public void Scroll()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://amazon.com");

            IWebElement element = driver.FindElement(By.Id("navBackToTop"));
            int deltay = element.Location.Y;

            WheelInputDevice.ScrollOrigin scrollOrigin = new WheelInputDevice.ScrollOrigin()
            {
                Viewport = true,
                XOffset = 50,
                YOffset = 50
            };
            Actions action = new Actions(driver);

            action.ScrollFromOrigin(scrollOrigin, 0, 500).Perform();

            Thread.Sleep(4000);

            driver.Quit();
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium;
using System.Threading;
using static System.Net.WebRequestMethods;

namespace SeleniumNUnit.TestCases
{
    public class SeleniumLocators
    {
        [Test]
        public void Locators()
        {
            
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://amazon.com");

            IWebElement element = driver.FindElement(By.Id("nav-hamburger-menu"));

            driver.FindElement(RelativeBy.WithLocator(By.TagName("a")).RightOf(element)).Click();
            driver.FindElement(RelativeBy.WithLocator(By.TagName("a")).LeftOf(By.Id("nav-orders"))).Click();

            driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Above(By.Id("continue"))).SendKeys("test@gmail.com");

            driver.FindElement(RelativeBy.WithLocator(By.TagName("input")).Below(By.Id("ap_email"))).Click();


            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNUnit.TestCases
{
    public class MouseHover
    {

        [Test]
        public void MouseHoverDemo()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://amazon.com");

            IWebElement element1 = driver.FindElement(By.XPath("//div[@class='ag-cell ag-cell-auto-height ag-cell-value ag-cell-not-inline-editing']"));
            element1.Click();
            element1 = driver.FindElement(By.XPath("//onelink-grid-custom-editor//input"));
            element1.SendKeys("5");



            IWebElement element = driver.FindElement(By.Id("nav-link-accountList"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();

            element = driver.FindElement(By.XPath("//a/span[text()='Create a List']"));
            element.Click();

        }

    }
}

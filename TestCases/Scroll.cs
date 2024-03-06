using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace SeleniumNUnit.TestCases
{
    public class Scroll
    {
        [Test]
        public void ScrollTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://amazon.com");

            IJavaScriptExecutor scriptExecutor = (IJavaScriptExecutor)driver;
            //scriptExecutor.ExecuteScript("window.scroll(100,1000)");
            //Thread.Sleep(2000);
            //scriptExecutor.ExecuteScript("window.scroll(100,2000)");
            //Thread.Sleep(2000);
            //scriptExecutor.ExecuteScript("window.scroll(100,3000)");

            IWebElement element = driver.FindElement(By.XPath("//div[@class='navFooterBackToTop']"));
            
            element.Click();
            
            //scriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();


        }
    }
}

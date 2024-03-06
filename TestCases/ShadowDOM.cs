using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium;
using System.Threading;
using NPOI.SS.Formula.Functions;
using NPOI.XWPF.UserModel;
using System.ComponentModel;
using Fare;
using System.IO;

using System.Threading.Tasks;


namespace SeleniumNUnit.TestCases
{
    public class ShadowDOM
    {
        [Test]
        public async Task DomTest()
        {
            //Recorder _rec;
            //string videoPath = Path.Combine(Path.GetTempPath(), "test.mp4");
            //_rec = Recorder.CreateRecorder();
            ////_rec.OnRecordingComplete += Rec_OnRecordingComplete;
            ////_rec.OnRecordingFailed += Rec_OnRecordingFailed;
            ////_rec.OnStatusChanged += Rec_OnStatusChanged;
            ////Record to a file
            ////string videoPath = Path.Combine(Path.GetTempPath(), "test.mp4");
            //_rec.Record(videoPath);



            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://amazon.com");
            IJavaScriptExecutor scriptExecutor = driver;
            IWebElement element = (IWebElement)scriptExecutor.ExecuteScript(@"return document.querySelector(""body > settings-ui"").shadowRoot.querySelector(""settings-main#main"")
                                .shadowRoot.querySelector(""settings-basic-page.cr-centered-card-container"").shadowRoot.querySelector(""settings-section[section='appearance']"")
                                .querySelector(""settings-appearance-page"").shadowRoot.querySelector(""settings-animated-pages#pages"").querySelector(""settings-toggle-button[label='Show home button']"")
                                .shadowRoot.querySelector(""cr-toggle#control"")");

            Thread.Sleep(3000);
            element.Click();
            Thread.Sleep(3000);
            driver.Quit();
            //_rec.Stop();

        }
    }
}

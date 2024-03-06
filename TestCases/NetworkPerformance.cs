using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.DevTools;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V104.Performance;
using OpenQA.Selenium;
using System.Security.Cryptography;

namespace SeleniumNUnit.TestCases
{
    public class NetworkPerformance
    {
        [Test]
        public async Task Perfromance()
        {

            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://corp-sit-uac.dev.local/launcher/dashboard");
            IJavaScriptExecutor scriptExecutor = (IJavaScriptExecutor)driver;

            scriptExecutor.ExecuteScript(@"return localStorage.getItem(""oidc.user:https://ids-sit-fun.dev.local/identityserver:launcherapp"")");


            IDevTools devTools = driver as IDevTools;
            DevToolsSession session = devTools.GetDevToolsSession();
            await session.SendCommand<EnableCommandSettings>(new EnableCommandSettings());
            var metricsResponse =
            await session.SendCommand<GetMetricsCommandSettings, GetMetricsCommandResponse>(
            new GetMetricsCommandSettings());
            driver.Navigate().GoToUrl("https://corp-sit-uac.dev.local/launcher/dashboard");
            var metrics = metricsResponse.Metrics;
            foreach (Metric metric in metrics)
            {
                Console.WriteLine("{0} = {1}", metric.Name, metric.Value);
            }
        }
    }
}

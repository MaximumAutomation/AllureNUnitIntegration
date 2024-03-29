﻿using Allure.Commons;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using SeleniumNUnit.Variables;
using SeleniumNUnitProject.StepDefinition;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Log = Serilog.Log;
using Status = AventStack.ExtentReports.Status;

namespace SeleniumNUnit.Hook
{
    [Binding]
    class Hooks 
    {        
        static AventStack.ExtentReports.ExtentReports extent;                
        [ThreadStatic]
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario,step;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result_" + DateTime.Now.ToString("ddMMyyyyHHmmss")+ Path.DirectorySeparatorChar;
        //static ExtentKlovReporter klovreport;
        public static ConfigSetting config;
        static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Configuration/configsetting.json";


        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            config = new ConfigSetting();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configsettingpath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);


            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            
            extent.AttachReporter(htmlreport);


            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Information);
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.ControlledBy(levelSwitch)
                        .WriteTo.File(new JsonFormatter(), reportpath + @"\Logs").CreateLogger();
            
                        
        }
    
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            feature = extent.CreateTest(context.FeatureInfo.Title);
            Log.Information("Selecting feature file {0} to run",context.FeatureInfo.Title);
        }
     
        [BeforeScenario]
        public void BeforeSceanrio(ScenarioContext context)
        {            
            scenario = feature.CreateNode(context.ScenarioInfo.Title);
            Log.Information("Selecting scenario {0} to run", context.ScenarioInfo.Title);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            step = scenario;
        }


        public string GetScreenshot()
        {
            return ((ITakesScreenshot)StepDefinition.webDriver).GetScreenshot().AsBase64EncodedString;
        }

      


        [AfterFeature]
        public static void AfterFeature()
        {
            extent.Flush();
        }


        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError != null)
            {
                byte[] content = CaptureScreenshot();
                AllureLifecycle.Instance.AddAttachment("Failed Screenshot", "application/png", content);
            }
        }


        public static byte[] CaptureScreenshot()
        {
            return ((ITakesScreenshot)StepDefinition.webDriver).GetScreenshot().AsByteArray;
        }
     
    }   


}

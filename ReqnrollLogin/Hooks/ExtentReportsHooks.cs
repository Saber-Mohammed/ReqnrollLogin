using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Reqnroll;
using ReqnrollLogin.Helpers;
using ReqnrollLogin.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollProject1.Hooks
{
    [Binding]
    internal class ExtentReportsHooks
    {
        private static ExtentReports extent;
        private static ExtentTest feature;
        private static ExtentTest scenario;

        //Define report path and file
        private static string reportPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "ExtentReports");
        private static string reportFile;// = Path.Combine(reportPath, "ExtentReports.html");
        private static string fileName;
        private static IWebDriver driver;
        private readonly WebDriverSupport _driverSupport;

        public ExtentReportsHooks(WebDriverSupport webDriverSupport)
        {
            _driverSupport = webDriverSupport;
            driver = _driverSupport.Driver;

        }

        public static void CaptureScreenShot()
        {
            DateTime currentDateTime = DateTime.Now;
            fileName = currentDateTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

            Screenshot screenshot = driver.TakeScreenshot();
            screenshot.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Screenshots\\" + fileName);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //If Directory does not exists, create directory
            if (!Directory.Exists(reportFile))
            {
                Directory.CreateDirectory(reportPath);
            }

            DateTime currentTime = DateTime.Now;
            string fileName = "Extent_" + currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".html";
            reportFile = Path.Combine(reportPath, fileName);

            var htmlReporter = new ExtentSparkReporter(reportFile);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = "BDD Test Suite";
            htmlReporter.Config.ReportName = "Automation Test Results";
            htmlReporter.Config.Encoding = "utf-8";

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Automation Tester", "Saber Mohammed");
            extent.AddSystemInfo("Organization Info", "SHM Tech");
            extent.AddSystemInfo("Build #", "v19.5.3.0");
        }
        [AfterTestRun]
        public static void FlushReport()
        {
            //Flush report once test completes
            extent.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create Feature node
            feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            //Create Scenario node
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            //Get Step Type information (When, Then, Given, And)
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //Get Step Info
            var stepInfo = ScenarioStepContext.Current.StepInfo.Text; ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();


            // If there are no execution errors add the nodes 
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepInfo);
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepInfo);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepInfo);
                else if (stepType == "And")
                    scenario.CreateNode<And>(stepInfo);
            }
            else
            {
                CaptureScreenShot();
                if (stepType == "Given")
                    scenario.CreateNode<Given>(stepInfo).Fail(scenarioContext.TestError.Message);
                else if (stepType == "When")
                    scenario.CreateNode<When>(stepInfo).Fail(scenarioContext.TestError.Message);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(stepInfo).Fail(scenarioContext.TestError.Message);
                else if (stepType == "And")
                    scenario.CreateNode<Given>(stepInfo).Fail(scenarioContext.TestError.Message);

            }
        }

    }
}

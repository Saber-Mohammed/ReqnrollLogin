using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using OpenQA.Selenium;
using ReqnrollLogin.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollLogin.Hooks
{
    [Binding]
    internal class BaseHooks
    {
        private readonly WebDriverSupport _driverSupport;
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string testUrl;
        public BaseHooks(WebDriverSupport driverSupport)
        {
            _driverSupport = driverSupport;
        }

        [BeforeTestRun]
        public static void ConfigureLogging()
        {
            var logFilePath = (Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Logs\\TestLog.log");

            if (System.IO.File.Exists(logFilePath))
            {
                System.IO.File.WriteAllText(logFilePath, string.Empty);
            }

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo(Directory.GetParent(Environment.CurrentDirectory)
                .Parent.Parent.FullName + "\\Resources\\log4net.config"));
            log.Info("Logging configuration completed...");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            // Code to execute before each scenario
        }
        [AfterScenario]
        public void AfterScenario()
        {           
            _driverSupport.QuitDriver();
        }
    }
}

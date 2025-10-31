using log4net;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using ReqnrollLogin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollLogin.Support
{
    internal class WebDriverSupport
    {
        private IWebDriver _driver;
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Setup context;
        private ScenarioContext _scenarioContext;
        public WebDriverSupport(Setup context, ScenarioContext scenarioContext)
        {
            this.context = context;
            _scenarioContext = scenarioContext;
        }

        public IWebDriver Driver
        {
            get 
            {
                if (_driver == null)
                {
                    log.Info("Initializing WebDriver");

                    try
                    {
                        switch (context.Browser)
                        {
                            case "Chrome":
                                ChromeOptions chromeOptions = new ChromeOptions();
                                chromeOptions.AddExcludedArgument("enable-automation");
                                _driver = new ChromeDriver(chromeOptions);
                                _driver.Manage().Window.Maximize();
                                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt16(context.ImplicitWait));
                                break;

                            case "Firefox":
                                _driver = new FirefoxDriver();
                                _driver.Manage().Window.Maximize();
                                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        log.Info("Failed to initialize WebDriver: " + e.Message);
                        throw new ArgumentException("Unsupported browser", e.Message);
                    }
                }
                return _driver;
            }
        }
        public void QuitDriver()
        {
            log.Info("Quiting WebDriver...");
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}

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
        //  private IWebDriver _driver;
        public static ThreadLocal<IWebDriver> _driver = new();

        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Setup _context;

        public WebDriverSupport(Setup context)
        {
            _context = context;
        }

        // Get unique thread value for each thread
        public IWebDriver GetDriver()
        {
            return _driver.Value;
        }

        //public IWebDriver Driver
        //{
        //    get 
        //    {
        //        if (_driver == null)
        //        {
        //            log.Info("Initializing WebDriver");

        //            try
        //            {
        //                switch (context.Browser)
        //                {
        //                    case "Chrome":
        //                        ChromeOptions chromeOptions = new ChromeOptions();
        //                        chromeOptions.AddExcludedArgument("enable-automation");
        //                        _driver = new ChromeDriver(chromeOptions);
        //                        _driver.Manage().Window.Maximize();
        //                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt16(context.ImplicitWait));
        //                        break;

        //                    case "Firefox":
        //                        _driver = new FirefoxDriver();
        //                        _driver.Manage().Window.Maximize();
        //                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        //                        break;
        //                }

        //            }
        //            catch (Exception e)
        //            {
        //                log.Info("Failed to initialize WebDriver: " + e.Message);
        //                throw new ArgumentException("Unsupported browser", e.Message);
        //            }
        //        }
        //        return _driver;
        //    }
        //}

        public IWebDriver InitializeWebBrowser()
        {
            switch (_context.Browser)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddExcludedArgument("enable-automation");
                    _driver.Value = new ChromeDriver(chromeOptions);
                    GetDriver().Manage().Window.Maximize();
                    GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt16(_context.ImplicitWait));
                    break;

                case "Firefox":
                    _driver.Value = new FirefoxDriver();
                    GetDriver().Manage().Window.Maximize();
                    GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    break;
            }
            //ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddExcludedArgument("enable-automation");
            //_driver.Value = new ChromeDriver(chromeOptions);
            //_driver.Value.Manage().Window.Maximize();
            //_driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt16(_context.ImplicitWait));
            return GetDriver();
        }
        public void QuitDriver()
        {
            log.Info("Quiting WebDriver...");
            if (_driver != null)
            {
                _driver.Value.Quit();
                _driver.Value.Dispose();
                _driver.Value = null;
            }
        }
    }
}

//using AventStack.ExtentReports;
//using log4net;
//using Microsoft.Extensions.Configuration;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.Extensions;
//using ReqnrollLogin.Support;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReqnrollLogin.Helpers
//{
//    internal class BaseHelperClass
//    {
//        //private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//        //public static ThreadLocal<ExtentTest> exTest = new();
//        //private static ExtentReports extent;
//        //IConfiguration configuration;
//        public static string fileName;
//        private static IWebDriver driver;
//        private readonly WebDriverSupport _driverSupport;

//        public BaseHelperClass(WebDriverSupport webDriverSupport)
//        {
//            _driverSupport = webDriverSupport;
//            driver = _driverSupport.Driver;
//            DateTime currentTime = DateTime.Now;
//            string fileName = "Extent_" + currentTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".html";
//        }

//        public static void CaptureScreenShot()
//        {
//            DateTime currentDateTime = DateTime.Now;
//            fileName = currentDateTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";

//            Screenshot screenshot = driver.TakeScreenshot();
//            screenshot.SaveAsFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Screenshots\\" + fileName);
//        }
//    }
//}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReqnrollLogin.Support;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollLogin.Pages
{
    internal class LoginPage
    {
        private IWebDriver _driver;
        private readonly WebDriverSupport _driverSupport;
        private ScenarioContext _scenarioContext;
        public LoginPage(WebDriverSupport driverSupport, ScenarioContext scenarioContext)
        {
            _driverSupport = driverSupport;
            _driver = _driverSupport.Driver;
            _scenarioContext = scenarioContext;

        }
        By usernameField = By.Id("username");
        By passwordField = By.Id("password");
        By submitButton = By.Id("submit");
        By errormessage = By.Id("error");
        By practice = By.XPath("//*[@id=\"menu-item-20\"]/a");
        By loginLing = By.XPath("//*[@id=\"loop-container\"]//a");
        By successMessage = By.XPath("//*[@id=\"loop-container\"]//h1");
        By welcomeMessage = By.XPath("//*[@id=\"loop-container\"]//strong");

        public void LaunchTheApplication(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
        public void NavigateToLoginPage()
        {
            _driver.FindElement(practice).Click();
            _driver.FindElement(loginLing).Click();
        }
        public void EnterUsername(string username)
        {
            _driver.FindElement(usernameField).SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            _driver.FindElement(passwordField).SendKeys(password);
        }
        public void ClickSubmit()
        {
            _driver.FindElement(submitButton).Click();
        }
        public string GetSuccessMessage()
        {
            return _driver.FindElement(successMessage).Text;
        }
        public string GetWelcomeMessage()
        {
            return _driver.FindElement(welcomeMessage).Text;
        }
        public string GetPassword()
        {
            return _driver.FindElement(passwordField).Text;
        }
        public string GetErrorMessage() 
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            IWebElement errMsg = wait.Until(ExpectedConditions.ElementIsVisible(errormessage));
            return errMsg.Text;
        }

    }
}

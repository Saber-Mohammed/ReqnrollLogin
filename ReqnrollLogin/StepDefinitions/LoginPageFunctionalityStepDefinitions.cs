using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollLogin.Helpers;
using ReqnrollLogin.Pages;
using ReqnrollLogin.Support;
using System;


namespace ReqnrollLogin.StepDefinitions
{
    [Binding]
    internal class LoginPageFunctionalityStepDefinitions
    {
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Setup _context;
        private LoginPage _loginPage;

        public LoginPageFunctionalityStepDefinitions(Setup context, LoginPage loginPage)
        {
            log.Info("Initializing LoginStepDefinitions");
            log.Info("Execution started");
            _context = context;
            _loginPage = loginPage;
        }

        [Given("the application is launched")]
        public void GivenTheApplicationIsLaunched()
        {
            log.Info("Starting test: " + TestContext.CurrentContext.Test.Name);
            _loginPage.LaunchTheApplication(_context.TestUrl);
        }

        [Given("I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.NavigateToLoginPage();
        }

        [When("I enter a valid username {string}")]
        public void WhenIEnterAValidUsername(string testuser)
        {
            _loginPage.EnterUsername(testuser);
        }

        [When("I enter a valid password {string}")]
        public void WhenIEnterAValidPassword(string password)
        {
            _loginPage.EnterPassword(password);
        }

        [When("I click on the submit button")]
        public void WhenIClickOnTheLoginButton()
        {
            _loginPage.ClickSubmit();
        }

        [Then("I should see a successful login message {string}")]
        public void ThenIShouldSeeASuccessfulLoginMessage(string successMsg)
        {
            Assert.AreEqual(successMsg, _loginPage.GetSuccessMessage());
        }

        [Then("I should see a welcome message {string}")]
        public void ThenIShouldSeeAWelcomeMessage(string welcomeMsg)
        {
            Assert.AreEqual(welcomeMsg, _loginPage.GetWelcomeMessage());
            log.Info("Execution ended");
        }

        [When("I enter an invalid username {string}")]
        public void WhenIEnterAnInvalidUsername(string wronguser)
        {
            _loginPage.EnterUsername(wronguser);
        }

        [When("I enter an invalid password {string}")]
        public void WhenIEnterAnInvalidPassword(string wrongpassword)
        {
            _loginPage.EnterPassword(wrongpassword);
        }

        [Then("I should see an error message {string}")]
        public void ThenIShouldSeeAnErrorMessage(string errorMsg)
        {
            Assert.AreEqual(errorMsg, _loginPage.GetErrorMessage());
        }

        [When("I leave the username and password field empty")]
        public void WhenILeaveTheUsernameAndPasswordFieldEmpty()
        {
            _loginPage.ClickSubmit();
        }

    }
}

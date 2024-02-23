using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;



namespace CreateBolFlow.StepDefinitions.Hero
{
    [Binding]
    public sealed class Login_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Login_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [Given(@"the user is on the Hero login page")]
        public void GivenTheUserIsOnTheHeroLoginPage()
        {
            driver.Navigate().GoToUrl("http://172.16.20.27:5421/Account/Login");
        }

        [When(@"the user fills the username field with '([^']*)' and the password field with '([^']*)'")]
        public void WhenTheUserFillsTheUsernameFieldWithAndThePasswordFieldWith(string userName, string password)
        {
            var usernameField = driver.FindElement(By.Name("UsernameOrEmailAddress"));
            var passwordField = driver.FindElement(By.Name("Password"));

            usernameField.SendKeys($"{userName}");
            passwordField.SendKeys($"{password}");
        }

        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            var submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                Id("hero-login-button")));
            submitButton.Click();
        }

        [Then(@"the user should be redirected to the Hero Home page")]
        public void ThenTheUserShouldBeRedirectedToTheHeroHomePage()
        {
            var homePage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                ClassName("hero-next-navbar")));
            Assert.True(homePage.Displayed);
        }
    }
}
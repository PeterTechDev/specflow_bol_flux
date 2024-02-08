using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;

public class WebDriverFixture
{
    public IWebDriver Driver { get; private set; }
    public WebDriverWait Wait { get; private set; }

    public WebDriverFixture()
    {

        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--headless");
        chromeOptions.AddArguments("--disable-gpu");
        chromeOptions.AddArguments("--window-size=1920,1080");

        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}


namespace CreateBolFlow.StepDefinitions.Rubicon
{
    [Binding]
    public sealed class Rubicon_UserLoginStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Rubicon_UserLoginStepDefinitions(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [Given(@"the Rubicon login page is displayed")]
        public void GivenTheRubiconLoginPageIsDisplayed()
        {
            driver.Navigate().GoToUrl("http://rubicon.wtecenergy.com/wtec_test/");
            wait.Until(d => d.FindElement(By.Name("login")).Displayed);
        }

        [When(@"the user enters valid login credentials")]
        public void WhenTheUserEntersValidLoginCredentials()
        {
            var usernameField = driver.FindElement(By.Name("login"));
            var passwordField = driver.FindElement(By.Name("password"));

            // Perform login as administrator
            usernameField.SendKeys("psouza");
            passwordField.SendKeys("Wtec123!");
        }

        [When(@"the user clicks the Login button")]
        public void WhenTheUserClicksTheButton()
        {
            var loginButton = driver.FindElement(By.ClassName("rgl-button-text"));
            loginButton.Click();
        }

        [Then(@"the Rubicon Home Page is displayed")]
        public void ThenTheRubiconHomePageIsDisplayed()
        {
            wait.Until(d => d.FindElement(By.ClassName("rgl-menu-item")).Displayed);
            var uniqueElement = driver.FindElement(By.ClassName("rgl-menu-item"));
            Assert.NotNull(uniqueElement);

            // driver.Dispose();

        }

    }
}
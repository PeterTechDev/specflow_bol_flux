using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;


namespace CreateBolFlow.StepDefinitions.Hero
{
    [Binding]
    public sealed class NavigateToBolList_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public NavigateToBolList_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [Given(@"the user is logged into Hero with username '([^']*)' and password '([^']*)'")]
        public void GivenTheUserIsLoggedIntoRubiconWithUsernameAndPassword(string username, string password)
        {
            driver.Navigate().GoToUrl("http://172.16.20.27:5421/Account/Login");

            var usernameField = driver.FindElement(By.Name("UsernameOrEmailAddress"));
            var passwordField = driver.FindElement(By.Name("Password"));

            usernameField.SendKeys($"{username}");
            passwordField.SendKeys($"{password}");

            var submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                Id("hero-login-button")));
            submitButton.Click();

            var homePage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                ClassName("hero-next-navbar")));
            Assert.True(homePage.Displayed);
        }

        [Given(@"the user is on the Hero home page")]
        public void GivenTheUserIsOnTheHeroHomePage()
        {
            var homePage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                ClassName("hero-next-navbar")));
            Assert.True(homePage.Displayed);
        }

        [When(@"the user clicks on the main menu")]
        public void WhenTheUserClicksOnTheMainMenu()
        {
            var mainMenu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                Id("main-switcher")));
            mainMenu.Click();
        }

        [When(@"the user selects the '([^']*)' option")]
        public void WhenTheUserSelectsTheOption(string menuName)
        {
            var WTECmenu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                XPath($"//span[text()='{menuName}']")));
            WTECmenu.Click();
        }

        [When(@"the user clicks on the '([^']*)' option")]
        public void WhenTheUserClicksOnTheOption(string menuName)
        {
            Thread.Sleep(500);
            var steelMenu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                XPath($"//span[text()='{menuName}']")));
            steelMenu.Click();
        }

        [When(@"the user navigates through '([^']*)', '([^']*)', to '([^']*)'")]
        public void WhenTheUserNavigatesThroughTo(string manufactoringMenu, string bolMenu, string listMenu)
        {
            Thread.Sleep(500);
            var manufactoringMenuItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                XPath($"//span[text()='{manufactoringMenu}']")));
            manufactoringMenuItem.Click();

            Thread.Sleep(500);
            var bolMenuItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                XPath($"//span[text()='{bolMenu}']")));
            bolMenuItem.Click();

            Thread.Sleep(500);
            var listMenuItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                XPath($"//span[text()='{listMenu}']")));
            listMenuItem.Click();
        }

        [Then(@"the BOL list page is displayed")]
        public void ThenTheBOLListPageIsDisplayed()
        {
            var bolsPage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                XPath($"//div[text()='BOLS']")));
            Assert.True(bolsPage.Displayed);
        }
    }
}
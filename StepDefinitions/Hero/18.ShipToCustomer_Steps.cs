using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;
using SeleniumExtras.WaitHelpers;
using System.Net.NetworkInformation;
using OpenQA.Selenium.Interactions;
using System.Security.Claims;



namespace CreateBolFlow.StepDefinitions.Hero
{
    [Binding]
    public sealed class ShipToCustomer_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

    public ShipToCustomer_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [When(@"the user clicks in the customer Select button")]
        public void WhenTheUserClicksInTheCustomerSelectButton()
        {
            Thread.Sleep(1000);
            var selectButton = driver.FindElements(By.XPath("//span[text()='Select']/.."));
            selectButton.Last().Click();
        }

        [When(@"the user clicks the customer ""([^""]*)"" button")]
        public void WhenTheUserClicksTheCustomerButton(string buttonTitle)
        {
            Thread.Sleep(1000);
            var shipButton = driver.FindElements(By.XPath($"//div[text()='{buttonTitle}']/.."));
            shipButton.Last().Click();
        }

        [Then(@"the user clicks on Save buttona")]
        public void ThenTheUserClicksOnSaveButtona()
        {
            throw new PendingStepException();
        }



        [Then(@"a message ""([^""]*)"" is displayed")]
        public void ThenAMessageIsDisplayed(string p0)
        {
            throw new PendingStepException();
        }

    }
}
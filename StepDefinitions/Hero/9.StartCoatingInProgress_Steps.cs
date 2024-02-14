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



namespace CreateBolFlow.StepDefinitions.Hero
{
    [Binding]
    public sealed class StartCoatingInProgress_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

    public StartCoatingInProgress_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [Then(@"the user enters a valid estimated pickup date ""([^""]*)""")]
        public void WhenTheUserEntersAValidEstimatedPickupDate(string pickupDate)
        {
            var dateInput = driver.FindElement(By.CssSelector("#EstimatedPickupDate .dx-texteditor-input"));
            dateInput.Clear();
            dateInput.SendKeys(pickupDate);
        }

    }
}
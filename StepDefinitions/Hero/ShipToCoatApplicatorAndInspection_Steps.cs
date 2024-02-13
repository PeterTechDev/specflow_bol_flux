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
    public sealed class ShipToCoatApplicatorAndInspection_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ShipToCoatApplicatorAndInspection_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [When(@"the user clicks in the Select button")]
        public void WhenTheUserClicksInTheSelectButton()
        {
            Thread.Sleep(1000);
            var selecButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//span[text()='Select']/..")));
            selecButton.Click(); 
        }

        [When(@"the user clicks in the button ""([^""]*)""")]
        public void WhenTheUserClicksInTheButton(string p0)
        {
            Thread.Sleep(1000);
            var shipButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//div[text()='Ship to Coating Applicator']/..")));
            shipButton.Click();
        }

        [When(@"the user enters a valid LRB number ""([^""]*)"" and adds it to the BOL")]
        public void WhenTheUserEntersAValidLRBNumberAndAddsItToTheBOL(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"the user attaches image files for inspection")]
        public void WhenTheUserAttachesImageFilesForInspection()
        {
            throw new PendingStepException();
        }

        [When(@"the user clicks on Save button")]
        public void WhenTheUserClicksOnSaveButton()
        {
            throw new PendingStepException();
        }


    }
}
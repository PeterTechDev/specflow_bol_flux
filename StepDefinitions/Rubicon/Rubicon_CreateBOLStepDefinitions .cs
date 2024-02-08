using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;

namespace CreateBolFlow.StepDefinitions.Rubicon
{
    [Binding]
    public class Rubicon_CreateBOLStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Rubicon_CreateBOLStepDefinitions(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [When(@"I click the 'Actions' button")]
        public void WhenIClickTheActionsButton()
        {

            var actionsButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Actions']")));
            actionsButton.Click();
        }

        [When(@"I select 'Create BOL' from the Actions dropdown")]
        public void WhenISelectCreateBOLFromTheActionsDropdown()
        {
            var createBOLDropdownOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Create BOL']")));
            createBOLDropdownOption.Click();
        }

        [Then(@"the 'Coating Applicator Bill Of Lading Entry' page is displayed")]
        public void ThenTheCoatingApplicatorBillOfLadingEntryPageIsDisplayed()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Coating Applicator Bill Of Lading Entry']")));
        }

        [When(@"I click the 'Submit' button on the BOL Entry page")]
        public void WhenIClickTheSubmitButtonOnTheBOLEntryPage()
        {
            var submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Submit']")));
            submitButton.Click();
        }

        [Then(@"a message 'BOL successfully created' is displayed")]
        public void ThenAMessageBOLSuccessfullyCreatedIsDisplayed()
        {
            var successMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Bill of lading created successfully']")));
            Assert.Equal("Bill of lading created successfully", successMessage.Text);
        }
    }
}
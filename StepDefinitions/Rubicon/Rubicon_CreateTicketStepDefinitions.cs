using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Reflection.Emit;



namespace CreateBolFlow.StepDefinitions.Rubicon
{
    [Binding]
    public class CreateTicketStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CreateTicketStepDefinitions(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }


        [When(@"the user selects the correct LRB ""([^""]*)"" from the list")]
        public void WhenTheUserSelectsTheCorrectLRBFromTheList(string lrbNumber)
        {
            var lrbNumberItem = wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(By.XPath($"//input[@data-lrb='{lrbNumber}']")));
            lrbNumberItem.Click();
        }

        [Then(@"a sucessful message ""([^""]*)"" is displayed")]
        public void ThenASucessfulMessageIsDisplayed(string successMessage)
        {
            var actualSuccessMessage = wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains(text(), '{successMessage}')]")));  
            Assert.True(actualSuccessMessage.Displayed);
        }
    }
}
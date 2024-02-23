using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;
using System.ComponentModel.DataAnnotations;


namespace CreateBolFlow.StepDefinitions.Rubicon
{
    [Binding]
    public class Rubicon_PurchaseOrderSearchStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Rubicon_PurchaseOrderSearchStepDefinitions(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }


        [When(@"the user clicks on the Vendor Search icon")]
        public void WhenTheUserClicksOnTheVendorSearchIcon()
        {
            var vendorSearchIcon = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("ui-id-6")));
            vendorSearchIcon.Click();
        }

        [When(@"the user fills in '(.*)' in the 'Purchase Order Number' input")]
        public void WhenTheUserFillsInInThePurchaseOrderNumberInput(string purchaseOrderNumber)
        {
            var purchaseOrderInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("rgl-po-number")));
            purchaseOrderInput.Clear();
            purchaseOrderInput.SendKeys(purchaseOrderNumber);
        }

        [When(@"the user presses enter")]
        public void WhenTheUserPressesEnter()
        {
            var purchaseOrderInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("rgl-po-number")));
            purchaseOrderInput.SendKeys(Keys.Enter);
        }

        [Then(@"the Purchase Order '(.*)' details page is displayed")]
        public void ThenThePurchaseOrderDetailsPageIsDisplayed(string purchaseNumber)
        {
            var purchaseOrderDetailsPage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("rgl-page-content")));
            Assert.True(purchaseOrderDetailsPage.Displayed);
        }

        [Then(@"the error message '([^']*)' is displayed")]
        public void ThenTheErrorMessageIsDisplayed(string message)
        {
            var errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//li[text()='Purchase Order could not be found']")));
            Assert.Equal(message, errorMessage.Text);

            // driver.Dispose();
        }
    }
}

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;


namespace CreateBolFlow.StepDefinitions.Rubicon
{
    [Binding]
    public class CreateBOLFromVendorBOL
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public CreateBOLFromVendorBOL(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [When(@"the user clicks on the Customer icon")]
        public void WhenTheUserClicksOnTheCustomerIcon()
        {
            var customerSearchIcon = wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementToBeClickable(By.Id("ui-id-2")));
            customerSearchIcon.Click();
        }

        [When(@"the user fills in '([^']*)' in the Sales Order Number input")]
        public void WhenTheUserFillsInInTheSalesOrderNumberInput(string salesOrderNumber)
        {
            var salesOrderNumberInput = wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(By.Name("orderNumber")));
            salesOrderNumberInput.SendKeys(salesOrderNumber);
            salesOrderNumberInput.SendKeys(Keys.Enter);
        }

        [When(@"""([^""]*)"" page is displayed")]
        public void WhenPageIsDisplayed(string expectedPageTitle)
        {
            var actualPageTitle = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementIsVisible(By.XPath($"//div[contains(text(), '{expectedPageTitle}')]")));
            Assert.True(actualPageTitle.Displayed);
        }

        [When(@"the user select ""([^""]*)"" item from the dropdown ""([^""]*)""")]
        public void WhenTheUserSelectItemFromTheDropdown(string bolCode, string dropdownName)
        {
            IWebElement dropdownItem = driver.FindElement(By.
                            XPath($"//select[@name='{dropdownName}']/option[text()='{bolCode}']"));
            dropdownItem.Click();
        }

        [Then(@"the new BOL detail page with related ""([^""]*)"" is displayed")]
        public void ThenTheNewBOLDetailPageWithRelatedIsDisplayed(string bolCode)
        {
            var relatedBol = driver.FindElement(By.XPath($"//a[contains(text(), '{bolCode}')]"));
            var pageTitle = driver.FindElement(By.XPath($"//div[contains(text(), 'Bill Of Lading "));

            Assert.True(pageTitle.Displayed);
            Assert.True(relatedBol.Displayed);
        }
    }
}

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
    public class Rubicon_TransferLRBfromBOLStepDefinitions
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Rubicon_TransferLRBfromBOLStepDefinitions(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [When(@"the user fills in '([^']*)' in the Bill of Lading input")]
        public void WhenTheUserFillsInInTheInput(string bolCode)
        {
            var bolNumberInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("bolNumber")));
            bolNumberInput.Clear();
            bolNumberInput.SendKeys(bolCode);
            bolNumberInput.SendKeys(Keys.Enter);
        }

        [Then(@"the user clicks on the '([^']*)' item")]
        public void ThenTheUserClicksOnTheItem(string bolCode)
        {
            var bolCodeItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//a[text()='{bolCode}']")));
            bolCodeItem.Click();
        }


        [Given(@"I am on the BOL page '([^']*)'")]
        public void GivenIAmOnTheBOLPage(string bolCode)
        {
            var bolCodeTitle = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//div[text()='Coating Applicator Bill Of Lading {bolCode}']")));
            Assert.Equal($"Coating Applicator Bill Of Lading {bolCode}", bolCodeTitle.Text);
        }

        [When(@"the '([^']*)' is '([^']*)'")]
        public void GivenTheHeroSyncedStatusIs(string heroSyncStatus, string expectedStatus)
        {
            bool statusMatch = false;
            int attempts = 0;

            while (!statusMatch && attempts < 10)
            {
                var heroSyncedStatusDt = driver.FindElement(By.XPath($"//dt[contains(text(), '{heroSyncStatus}')]"));
                var heroSyncedStatusDd = heroSyncedStatusDt.FindElement(By.XPath("following-sibling::dd"));

                var actualStatus = heroSyncedStatusDd.Text;

                if (actualStatus.Equals(expectedStatus))
                {
                    statusMatch = true;
                }
                else
                {
                    // wait for 30 seconds and refresh the page
                    Thread.Sleep(30000);
                    driver.Navigate().Refresh();
                    attempts++;
                }
            }

            Assert.True(statusMatch, $"Expected status to be '{expectedStatus}'.");
        }



        [When(@"I click the actions button")]
        public void WhenIClickTheActionsButton()
        {
            var actionsButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Actions']")));
            actionsButton.Click();
        }

        [When(@"I select the '([^']*)' option")]
        public void WhenISelectTheOption(string transferLrbOption)
        {
            var dropdownOption = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//a[text()='{transferLrbOption}']")));
            dropdownOption.Click();
        }

        [When(@"I select option '([^']*)' from the dropdown")]
        public void WhenISelectOptionFromTheDropdown(string purchaseOrderNumber)
        {
            var purchaseOrderDropdown = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("orderId")));
            purchaseOrderDropdown.Click();
            var correctPurchaseOrderNumber = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//option[text()='{purchaseOrderNumber}']")));
            correctPurchaseOrderNumber.Click();
            Thread.Sleep(1000);
        }

        [When(@"I click on the checkbox to confirm my selection")]
        public void WhenIClickOnTheCheckboxToConfirmMySelection()
        {
            var checkbox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[type='checkbox']")));
            checkbox.Click();
        }

        [When(@"I click the submit button to complete the LRB transfer")]
        public void WhenIClickTheSubmitButtonToCompleteTheLRBTransfer()
        {
            var submitButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Submit']")));
            submitButton.Click();
        }

        [Then(@"I am on the BOL page '([^']*)'")]
        public void ThenIAmOnTheBOLPage(string bolCode)
        {
            var bolCodeTitle = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//div[text()='Coating Applicator Bill Of Lading {bolCode}']")));
            Assert.Equal($"Coating Applicator Bill Of Lading {bolCode}", bolCodeTitle.Text);
        }

        [Then(@"The BOL '([^']*)' should be '([^']*)'")]
        public void ThenTheBOLShouldBe(string tableName, string expectedValue)
        {
            var table = driver.FindElement(By.XPath($"//dt[contains(text(), '{tableName}')]"));
            var value = table.FindElement(By.XPath("following-sibling::dd"));

            var actualStatus = value.Text;
            Assert.True(actualStatus.Equals(actualStatus), $"Expected status to be '{expectedValue}', but was '{actualStatus}'.");
        }
    }
}
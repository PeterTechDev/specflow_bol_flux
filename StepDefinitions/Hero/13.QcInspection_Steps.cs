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
    public sealed class QcInspection_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

    public QcInspection_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }
        //Quality Inspection List
        [Then(@"the Quality Inspection list is displayed")]
        public void ThenTheQualityInspectionListIsDisplayed()
        {
            var qualitInspectionListTitle = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//div[text()='Quality Inspection List']")));
            Assert.True(qualitInspectionListTitle.Displayed);
        }

        [When(@"the user clicks the Select button for a BOL in the list")]
        public void WhenTheUserClicksTheSelectButtonForABOLInTheList()
        {
            var selectButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                XPath("//td[@aria-colindex='13']//span[text()='Select']/..")));
            selectButton.Click();
        }
        [When(@"the user clicks the ""([^""]*)"" button")]
        public void WhenTheUserClicksTheButton(string buttonTitle)
        {
            Thread.Sleep(1000);
            var selecButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                XPath($"//div[text()='{buttonTitle}']/..")));
            selecButton.Click();
        }

        [Then(@"the ""([^""]*)"" page is displayed")]
        public void ThenThePageIsDisplayed(string pageTitle)
        {
            var actualPageTitle = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                XPath($"//div[contains(text(), '{pageTitle}')]")));
            Assert.True(actualPageTitle.Displayed);
        }

        [When(@"the user checks ""([^""]*)"" on the radio inputs for inspection criteria")]
        public void WhenTheUserChecksOnTheRadioInputsForInspectionCriteria(string yes)
        {
            CheckRadioButtons(yes);

            try
            {
                IWebElement pagination = driver.FindElement(By.XPath("//div[contains(@class, 'dx-info') and contains(text(), 'Page')]"));
                if (pagination.Displayed)
                {
                    // Find element and cilck on the next page
                    IWebElement pageTwo = driver.FindElement(By.XPath("//div[contains(@class, 'dx-page') and text()='2']"));
                    pageTwo.Click();
                    Thread.Sleep(1000); // Wait for the page to load

                    CheckRadioButtons(yes); // Call the function again for the new page
                }
            }
            catch (NoSuchElementException)
            {
                    // Do nothing
            }
        }

        private void CheckRadioButtons(string yes)
        {
            int index = 1;
            var xpath = $"(//div[contains(@class, 'dx-radiobutton')]//div[contains(text(), '{yes}')])[{index}]";
            var radioButtonWithYes = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(xpath)));

            while (radioButtonWithYes != null)
            {
                radioButtonWithYes = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
                radioButtonWithYes.Click();
                Thread.Sleep(500); // To load the next radio button

                index++;
                xpath = $"(//div[contains(@class, 'dx-radiobutton')]//div[contains(text(), '{yes}')])[{index}]";
                var elements = driver.FindElements(By.XPath(xpath));
                radioButtonWithYes = elements.Any() ? elements.First() : null;
            }
        }

        [When(@"the user attaches a picture file for the quality inspection evidence")]
        public void WhenTheUserAttachesAPictureFileForTheQualityInspectionEvidence()
        {
            var inspectionEvidenceInput = driver.FindElement(By.CssSelector("input[type='file'][name='fileType4']"));

            string[] filePaths = {
                @"C:\bolPics\steel1.jpg",
                @"C:\bolPics\steel2.jpg",
                @"C:\bolPics\steel3.jpg",
                @"C:\bolPics\steel4.jpg"
            };

            string combinedPaths = string.Join("\n", filePaths);
            inspectionEvidenceInput.SendKeys(combinedPaths);
        }
    }
}
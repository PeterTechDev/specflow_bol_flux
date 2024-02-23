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
using System.ComponentModel;
using LivingDoc.Dtos;


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
            var selecButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                XPath($"//span[text()='Select']/..")));
            selecButton.Click(); 
        }

        [Then(@"the user clicks in the button ""([^""]*)""")]
        public void WhenTheUserClicksInTheButton(string buttonTitle)
        {
            var dropdownElements = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                PresenceOfAllElementsLocatedBy(By.ClassName("dx-scrollview-content")));

            if (dropdownElements.Count >= 2)
            {
                var dropdown = dropdownElements[1];

                int yOffset = -5;
                Actions actions = new Actions(driver);
                actions.MoveToElement(dropdown, 0, yOffset).Click().Perform();
            }
            else
            {
                throw new NoSuchElementException("The dropdown element with the specified class was not found or there are not enough elements.");
            }
        }

        [Then(@"the user enters a valid LRB number ""([^""]*)"" and adds it to the BOL")]
        public void WhenTheUserEntersAValidLRBNumberAndAddsItToTheBOL(string lrbNumber)
        {
            var lrbNumberDiv = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
                Id("hero-next-lrb-number-search")));
            lrbNumberDiv.Click();

            var lrbNumberInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.
                CssSelector("#hero-next-lrb-number-search .dx-texteditor-input")));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'nearest', inline: 'nearest'});", lrbNumberInput);

            lrbNumberInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lrbNumberInput));

            lrbNumberInput.Clear();
            lrbNumberInput.SendKeys(lrbNumber);

            IWebElement addLrbButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@aria-label='Add LRB']")));
            addLrbButton.Click();
        }

        [When(@"the user attaches image files for inspection")]
        public void WhenTheUserAttachesImageFilesForInspection()
        {
            var shippingPictures  = driver.FindElement(By.CssSelector("input[type='file'][name='fileType1']"));
            var signedBOL         = driver.FindElement(By.CssSelector("input[type='file'][name='fileType2']"));
            var signedPackingSlip = driver.FindElement(By.CssSelector("input[type='file'][name='fileType3']"));

            string[] filePaths = {
                @"C:\bolPics\steel1.jpg",
                @"C:\bolPics\steel2.jpg",
                @"C:\bolPics\steel3.jpg",
                @"C:\bolPics\steel4.jpg"
            };

            var filePath = @"C:\bolPics\steel1.jpg";

            string combinedPaths = string.Join("\n", filePaths);
            shippingPictures.SendKeys(combinedPaths);

            signedBOL.SendKeys(filePath);
            signedPackingSlip.SendKeys(filePath);
        }

        [Then(@"the user clicks on Save button")]
        public void WhenTheUserClicksOnSaveButton()
        {
            Thread.Sleep(2000);
            // Click the save button when it is clickable
            var saveButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Save']")));
            saveButton.Click();

            while (true) // Loop indefinitely until we manually break out
            {
                IWebElement errorAlert;
                try
                {
                    // Attempt to find the error alert
                    errorAlert = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Status code: 500']")));

                    // If found, close the error modal
                    var closeModal = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                        ElementToBeClickable(By.ClassName("hero-close-alert")));
                    closeModal.Click();

                    saveButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Save']")));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", saveButton);
                    Thread.Sleep(3000); // Wait for the "Save" button to be clickable again after closing the modal
                    saveButton.Click();
                }
                catch (Exception ex) when (ex is NoSuchElementException || ex is WebDriverTimeoutException)
                {
                    // If the error alert is no longer visible, break the loop
                    break;
                }
            }
        }


        [Then(@"message ""([^""]*)"" is displayed")]
        public void ThenMessageIsDisplayed(string successMessage)
        {
            var message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains(text(), '{successMessage}')]")));

            Assert.True(message.Displayed, $"The message containing '{successMessage}' is not displayed.");
        }
    }
}
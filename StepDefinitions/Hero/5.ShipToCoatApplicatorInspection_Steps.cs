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
        public void WhenTheUserClicksInTheButton(string buttonTitle)
        {
            // Find the dropdown element by class name
            var dropdownElements = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                PresenceOfAllElementsLocatedBy(By.ClassName("dx-scrollview-content")));

            // Make sure we have at least two elements and take the second one (index 1)
            if (dropdownElements.Count >= 2)
            {
                var dropdown = dropdownElements[1]; // This is the second element with the 'dx-scrollview-content' class


                // Define the offset in pixels from the top of the dropdown element where the click should occur
                int yOffset = -5;  // Changed from 30 to 15 pixels

                // Move to the element and offset 15 pixels down from the top and perform the click
                Actions actions = new Actions(driver);
                actions.MoveToElement(dropdown, 0, yOffset).Click().Perform();
            }
            else
            {
                throw new NoSuchElementException("The dropdown element with the specified class was not found or there are not enough elements.");
            }
        }



        [When(@"the user enters a valid LRB number ""([^""]*)"" and adds it to the BOL")]
        public void WhenTheUserEntersAValidLRBNumberAndAddsItToTheBOL(string lrbNumber)
        {
            // Click the div to make sure the input is ready for interaction
            var lrbNumberDiv = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("hero-next-lrb-number-search")));
            lrbNumberDiv.Click();

            // Wait for the input within the container div to be present in the DOM
            var lrbNumberInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("#hero-next-lrb-number-search .dx-texteditor-input")));

            // Ensure the input is visible and interactable
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'nearest', inline: 'nearest'});", lrbNumberInput);

            // Wait until the input is clickable after it's scrolled into view
            lrbNumberInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(lrbNumberInput));

            // Clear any existing value in the input and send the new value
            lrbNumberInput.Clear();
            lrbNumberInput.SendKeys(lrbNumber);

            var addLrbButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@aria-label='Add LRB']")));
            addLrbButton.Click();
        }

        [When(@"the user attaches image files for inspection")]
        public void WhenTheUserAttachesImageFilesForInspection()
        {
            var shippingPictures = driver.FindElement(By.CssSelector("input[type='file'][name='fileType1']"));
            var signedBOL = driver.FindElement(By.CssSelector("input[type='file'][name='fileType2']"));
            var signedPackingSlip = driver.FindElement(By.CssSelector("input[type='file'][name='fileType3']"));

            // Assuming the file paths are defined here. Adjust the paths as needed.
            string[] filePaths = {
                @"C:\bolPics\steel1.jpg",
                @"C:\bolPics\steel2.jpg",
                @"C:\bolPics\steel3.jpg",
                @"C:\bolPics\steel4.jpg"
            };

            var filePath = @"C:\bolPics\steel1.jpg";

            // Join the file paths with a newline character, which acts as a separator for multiple files.
            string combinedPaths = string.Join("\n", filePaths);
            shippingPictures.SendKeys(combinedPaths);

            signedBOL.SendKeys(filePath);
            signedPackingSlip.SendKeys(filePath);
        }

        [Then(@"the user clicks on Save button")]
        public void WhenTheUserClicksOnSaveButton()
        {
            //need to be that way to avoid misteryous error 500 when clicking the save button
            Thread.Sleep(2000);
            var saveButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Save']")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({behavior: 'smooth', block: 'center', inline: 'center'});", saveButton);

            try
            {
                saveButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                var closeModal = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("hero-close-alert")));
                closeModal.Click();

                Thread.Sleep(5000);
                saveButton.Click();
            }
        }


        [Then(@"message ""([^""]*)"" is displayed")]
        public void ThenMessageIsDisplayed(string sucessfulyMessage)
        {
            var message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
                XPath($"//span[text()='{sucessfulyMessage}']")));

            Assert.True(message.Displayed);
        }
    }
}